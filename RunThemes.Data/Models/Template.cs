namespace RunThemes.Data.Models
{
    public class Template : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Downloads { get; set; }
        public int Rating { get; set; }
        public string DemoLink { get; set; }
    }
}
