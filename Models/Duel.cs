using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TriviaProject.Models
{
    public class Duel
    {
        [Key]
        public int DuelId { get; set; }

        public int User1Id { get; set; }
        public User User1 { get; set; }

        public int User2Id { get; set; }
        public User User2 { get; set; }
        public List<Result> Trivia { get; set; }
    }
}