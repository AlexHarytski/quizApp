namespace quizApp.Persistence
{
    public class QuizUOW
    {
        public QuizRepository QuizRepository { get; set; }
        public UserRepository UserRepository { get; set; }
        public QuizResultRepository QuizResultRepository { get; set; }

        public QuizUOW(IQuizDatabaseSettings dbSettings)
        {
            QuizRepository = new QuizRepository(dbSettings);
            UserRepository = new UserRepository(dbSettings);
            QuizResultRepository = new QuizResultRepository(dbSettings);
        }
    }
}