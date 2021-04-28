using System.Collections.Generic;

namespace TriviaProject.Models
{
    public class Root
    {
        public int response_code { get; set; }
        public List<Result> results { get; set; }
    }
}