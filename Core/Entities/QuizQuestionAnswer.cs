using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class QuizQuestionAnswer
    {
        public Guid Id { get; set; }

        public List<QuizQuestion> Questions { get; set; }

        public Guid QuestionId { get; set; }

        public string Title { get; set; }

    }
}
