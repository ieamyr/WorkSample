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
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int Time { get; set; }
        public int LessonId { get; set; }

        [ForeignKey("LessonId")]
        public virtual Lesson Lesson { get; set; }
    }
}