using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWork.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        [Display(Name = "موضوع درس")]
        public string LessonTitle { get; set; }
        public int CouerseId { get; set; }

        [ForeignKey("CouerseId")]
        public virtual Couerse Couerse { get; set; }
        public virtual ICollection<VideoTitle> VideoTitle { get; set; }
    }
}