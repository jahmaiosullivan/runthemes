using System;
using WhiteLabel.Common.Attributes;

namespace WhiteLabel.Data.Models
{
    public class Post
    {
        [AutoSuppliedFromDatabase]
        [PrimaryKey]
        public long PostId { get; set; }
        public string Message { get; set; }
        public Guid PostedBy { get; set; }
        public DateTime? PostedDate { get; set; }
    }
}
