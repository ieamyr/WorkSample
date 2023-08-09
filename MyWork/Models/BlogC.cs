using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWork.Models
{
    public class BlogC
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Preamble { get; set; }
        public String CreatedDate { get; set; }
        public string Image { get; set; }
    }
}