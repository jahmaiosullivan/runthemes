using System;
using RunThemes.Common.Attributes;

namespace RunThemes.Data.Models
{
    public class PostComment
    {
        [AutoSuppliedFromDatabase]
        [PrimaryKey]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Message { get; set; }
        public Guid CommentedBy { get; set; }
        public DateTime CommentedDate { get; set; }

        [DapperIgnoreOnSaveOrUpdate]
        public virtual Post Post { get; set; }

        [DapperIgnoreOnSaveOrUpdate]
        public virtual User UserProfile { get; set; }
    }
}
