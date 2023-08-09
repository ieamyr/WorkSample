using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MyWork.Models
{
    // Principal (parent)
    public class Couerse
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "موضوع")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        [Display(Name = "عکس")]
        public string Image { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}