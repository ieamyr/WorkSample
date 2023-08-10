using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWork.Models
{
    public class VideoTitle
    {
        [Key]
        public int VideoTitleId { get; set; }
        [Display(Name = "موضوع")]
        public string Title { get; set; }
        [Display(Name = "لینک فیلم")]
        public string VideoUrl { get; set; }
        [Display(Name = "تایم فیلم")]
        public int Time { get; set; }
        public int LessonId { get; set; }

        [ForeignKey("LessonId")]
        public virtual Lesson Lesson { get; set; }
    }
}