using System;

namespace RunThemes.Data.Models
{
    public class UserDownload : ModelBase
    {
        public Guid UserId { get; set; }
        public long TemplateId { get; set; }
        public DateTime Expires { get; set; }
    }
}
