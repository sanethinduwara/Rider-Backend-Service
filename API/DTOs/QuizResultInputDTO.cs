using System;
using System.Collections.Generic;
using System.Text;

namespace API.DTOs
{
    public class QuizResultInputDTO
    {
        public Guid userId { get; set; }

        public Guid quizId { get; set; }

        public int score { get; set; }

    }
}
