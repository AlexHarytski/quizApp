namespace quizApp.Persistence
{
    public class QuizUow
    {
        public QuizRepository QuizRepository { get; set; }
        public UserRepository UserRepository { get; set; }
        public QuizResultRepository QuizResultRepository { get; set; }

        public QuizUow(IQuizDatabaseSettings dbSettings)
        {
            QuizRepository = new QuizRepository(dbSettings);
            UserRepository = new UserRepository(dbSettings);
            QuizResultRepository = new QuizResultRepository(dbSettings);
        }
    }
}