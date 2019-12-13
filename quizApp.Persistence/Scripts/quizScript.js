use quizdb;
db.User.insertMany([
    {UserName: "rolit", Email: "rolit@andersenlab.com", Password: "123", Gender: "male", DateRegistration: new Date()},
    {UserName: "lisyak", Email: "lisyak@andersenlab.com", Password: "321", Gender: "male", DateRegistration: new Date()},
    {UserName: "boba", Email: "boba@andersenlab.com", Password: "228", Gender: "female", DateRegistration: new Date()},
    {UserName: "biba", Email: "biba@andersenlab.com", Password: "1488", Gender: "male", DateRegistration: new Date()}
]);
db.Quiz.insertOne({
    Title: "some quiz",
    QuizType: "music",
    QuizQuestion: [
        { 
            Title: "question1",
            Question: "how are you?",
            Score: 9999,
            QuizVariant: [
                { VariantText: "fine", IsCorrect: true },
                { VariantText: "cool", IsCorrect: true}
            ]
        }
    ]
});
db.createCollection("QuizResult");