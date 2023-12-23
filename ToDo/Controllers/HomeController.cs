using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers {
    [ApiController]
    public class HomeController : ControllerBase{
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDBContext contexto)
            => Ok(contexto.Todos.ToList());
        

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDBContext contexto){
            var todos = contexto.Todos.FirstOrDefault(x => x.Id == id);
            if (todos == null)
                return NotFound();

            return Ok(todos);
        }
        

        [HttpPost("/")]
        public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDBContext contexto) {
            contexto.Todos.Add(todo);
            contexto.SaveChanges();
            
            return Created($"{todo.Id}", todo);
        }
        
        [HttpPut("/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDBContext contexto) {
            var model = contexto.Todos.FirstOrDefault(x => x.Id == id);

            if (model == null) 
                return NotFound();

            model.Titulo = todo.Titulo;
            model.Pronta = todo.Pronta;

            contexto.Todos.Update(model);
            contexto.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDBContext contexto) {
            var model = contexto.Todos.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            contexto.Todos.Remove(model);
            contexto.SaveChanges();

            return Ok(model);
        }
    }
}