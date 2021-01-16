using System;
using System.Collections.Generic;
using System.Text;

namespace API.DTOs
{
    class QuizDTO
    {
        public Guid Id { get; set; }

        public List<QuizQuestionDTO> Questions { get; set; }

    }
}
