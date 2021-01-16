using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Comment
    {
        /// <summary>
        /// Identification
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Comment Body
        /// </summary>
        public string CommentBody { get; set; }

        /// <summary>
        /// Created on
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Owner of the comment
        /// </summary>
        public ApplicationUser Owner { get; set; }
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Review that this comment belongs to 
        /// </summary>
        public Review Review { get; set; }
        public Guid ReviewId { get; set; }

        /// <summary>
        /// Likes for this comment
        /// </summary>
        public virtual List<CommentLike> Likes { get; set; }

    }
}
