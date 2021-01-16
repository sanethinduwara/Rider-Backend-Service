using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class QuizQuestion
    {
        public Guid Id { get; set; }

        public Quiz Quiz { get; set; }

        public Guid QuizId { get; set; }

        public string AnswerOptions { get; set; }

        public string CorrectAnswer { get; set; }

        public string Title { get; set; }

        public int Time { get; set; }

        public int Points { get; set; }

    }
}
