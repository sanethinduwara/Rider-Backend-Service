using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }

        public Place Place { get; set; }

        public Guid PlaceId { get; set; }

        public virtual List<QuizQuestion> Questions { get; set; }

    }
}
