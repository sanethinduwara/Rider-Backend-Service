using System;
using System.Collections.Generic;
using System.Text;

namespace API.DTOs
{
    class QuizQuestionDTO
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
        public int Time { get; set; }
        public int Points { get; set; }
        public string Options { get; set; }
        public string CorrectAnswer { get; set; }

    }
}
