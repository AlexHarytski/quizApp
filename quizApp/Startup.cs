using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using quizApp.Application.Handlers;
using quizApp.Persistence;
using  quizApp.Application.Queries;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using quizApp.Domain.Models;
using quizApp.HealthCheck;

namespace quizApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<QuizDatabaseSettings>(Configuration.GetSection(nameof(QuizDatabaseSettings)));
            services.AddSingleton<IQuizDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value);
            services.AddSingleton(sp =>
                new MongoClient(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.ConnectionString)
                    .GetDatabase(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.DatabaseName)
                    .GetCollection<User>(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.UserCollectionName)
                );
            services.AddSingleton(sp =>
                new MongoClient(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.ConnectionString)
                    .GetDatabase(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.DatabaseName)
                    .GetCollection<Quiz>(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.QuizCollectionName)
                );        
            services.AddSingleton(sp =>
                new MongoClient(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.ConnectionString)
                    .GetDatabase(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.DatabaseName)
                    .GetCollection<QuizResult>(sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value.QuizResultCollectionName)
                );
            services.AddSingleton<IRepositoryGeneric<Quiz>>(sp => new QuizRepository(
                sp.GetService<IMongoCollection<Quiz>>()
                ));
            services.AddSingleton<IRepositoryGeneric<QuizResult>>(sp => new QuizResultRepository(
                sp.GetService<IMongoCollection<QuizResult>>()
                ));
            services.AddSingleton<IRepositoryGeneric<User>>(sp => new UserRepository(
                sp.GetService<IMongoCollection<User>>()
                ));
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "QuizApi", Version = "v1"});
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OpenIdConnect,
                    Name = "quizApi",
                    OpenIdConnectUrl = new Uri("http://localhost:5000"),
                    Flows = new OpenApiOAuthFlows()
                    {
                        ClientCredentials = new OpenApiOAuthFlow()
                        {
                            Scopes = 
                            {
                                { "client_id", "bob"},
                                { "password", "bob" }
                            }
                        }
                    }
                    
                    
                });


            });
            services.AddMediatR(typeof(quizApp.Application.Handlers.GetAllQuizzesHandler).Assembly);
            services.AddControllers();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "quizApi";
                });
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:5003")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddHealthChecks()
                .AddCheck<DatabaseHealthCheck>("database_check");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuizApi V1"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("default");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
