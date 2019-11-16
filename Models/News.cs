using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class News
    {
        public long Id { get; set; }
        public string LinkSrc { get; set; }
        public string ImageSrc { get; set; }
        public string Title { get; set; }
        public string P { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
