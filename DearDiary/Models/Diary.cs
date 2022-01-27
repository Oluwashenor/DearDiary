using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DearDiary.Models
{
    public class Diary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}