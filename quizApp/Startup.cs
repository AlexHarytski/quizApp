using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using quizApp.Application.Handlers;
using quizApp.Persistence;
using  quizApp.Application.Queries;
using Microsoft.OpenApi.Models;

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
            services.AddSwaggerGen( c =>
                c.SwaggerDoc("v1", new OpenApiInfo{Title = "QuizApi", Version = "v1"})
            );
            services.AddMediatR(typeof(quizApp.Application.Handlers.GetAllQuizzesHandler).Assembly);
            services.AddControllers();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
