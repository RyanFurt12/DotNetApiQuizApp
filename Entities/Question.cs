using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApiQuizApp.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<Option> Options { get; set; } = [];

        public int QuizId { get; set; }
    }

    public class Option
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Alias { get; set; }

        public int QuestionId { get; set; }
    }

    public class Result
    {
        [Key]
        public int Id { get; set; }
        public string? Alias { get; set; }
        public string? Text { get; set; }

        public int QuizId { get; set; }
    }
}