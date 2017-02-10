using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Meeeedium.Models
{
    public class BlogSearch
    {
        public string Search { get; set; }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TeaserText { get; set; }
        public DateTime Created { get; set; }
        public string Body { get; set; }
        public bool Public { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser Owner { get; set; }

    }
}
