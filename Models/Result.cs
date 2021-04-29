using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaProject.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }

        [NotMapped]
        public List<string> incorrect_answers { get; set; }

        [NotMapped]
        public bool user_answer { get; set; } = true;


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}