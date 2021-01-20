using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class VisitedPlace
    {
        public Guid Id { get; set; }

        public Place Place { get; set; }
        public Guid PlaceId { get; set; }

        public ApplicationUser User { get; set; }
        public Guid UserId { get; set; }
    }
}
