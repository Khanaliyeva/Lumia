using Lumia.Models.Common;

namespace Lumia.Models
{
    public class Team:BaseEntity
    {
        public string FullName { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        public string? Icon { get; set;}
    }
}
