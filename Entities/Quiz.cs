using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApiQuizApp.Entities
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<Question> Questions { get; set; } = [];
        public ICollection<Result> Results { get; set; } = [];
    }
}