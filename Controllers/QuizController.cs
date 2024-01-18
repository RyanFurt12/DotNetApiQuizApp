using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApiQuizApp.Data;
using DotNetApiQuizApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetApiQuizApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController(DbController dbContext) : ControllerBase
    {
        private readonly DbController _dbContext = dbContext 
            ?? throw new ArgumentNullException(nameof(dbContext));

        // Gets

        [HttpGet]
        public ActionResult<IEnumerable<Quiz>> GetAll([FromQuery] int page = 1, int pageSize = 10)
        {
            var quizzes = _dbContext.Quizzes
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            return Ok(quizzes);
        }


        [HttpGet("{id}")]
        public ActionResult<Quiz> Get(int id)
        {
            var quiz = _dbContext.Quizzes
                        .Include(q => q.Questions) 
                            .ThenInclude(q => q.Options)
                        .Include(q => q.Results)
                        .FirstOrDefault(q => q.Id == id);

            if (quiz == null) return NotFound("Quiz não encontrado");

            return Ok(quiz);
        }






        // Post
        [HttpPost]
        public IActionResult CreateQuiz([FromBody] Quiz quiz)
        {
            try
            {
                if (quiz == null)
                {
                    return BadRequest("Dados inválidos");
                }

                if (_dbContext == null)
                {
                    return StatusCode(500, "Erro interno de servidor");
                }

                quiz.Id = 0;
                foreach (var question in quiz.Questions) {
                    question.Id = 0;
                    foreach (var option in question.Options) option.Id = 0;
                }
                foreach (var result in quiz.Results) result.Id = 0;

                _dbContext.Quizzes.Add(quiz);
                _dbContext.SaveChanges();

                return Ok("Quiz criado com sucesso");
            }
            catch (Exception ex)
            {
                // Registre o erro nos logs
                Console.WriteLine($"Erro interno: {ex.Message}");
                return StatusCode(500, "Erro interno de servidor");
            }
        }





        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz(int id)
        {
            try
            {
                var quiz = _dbContext.Quizzes
                        .Include(q => q.Questions) 
                            .ThenInclude(q => q.Options)
                        .Include(q => q.Results)
                        .FirstOrDefault(q => q.Id == id);

                if (quiz == null) return NotFound("Quiz não encontrado");
            
                _dbContext.Quizzes.Remove(quiz);
                _dbContext.SaveChanges();

                return Ok("Quiz excluído com sucesso");
            }
            catch (Exception ex)
            {
                // Registra o erro nos logs
                Console.WriteLine($"Erro ao excluir o quiz com ID {id}: {ex.Message}");

                // Examine a exceção interna
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                return StatusCode(500, "Erro interno de servidor");
            }
        }


        
    }
}