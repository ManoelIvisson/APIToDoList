using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers {
    [ApiController]
    public class HomeController : ControllerBase{
        [HttpGet("/")]
        public List<TodoModel> Get([FromServices] AppDBContext contexto){
            return contexto.Todos.ToList();
        }

        [HttpGet("/{id:int}")]
        public TodoModel GetById([FromRoute] int id, [FromServices] AppDBContext contexto){
            return contexto.Todos.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("/")]
        public TodoModel Post([FromBody] TodoModel todo, [FromServices] AppDBContext contexto) {
            contexto.Todos.Add(todo);
            contexto.SaveChanges();
            
            return todo;
        }
        
        [HttpPut("/{id:int}")]
        public TodoModel Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDBContext contexto) {
            var model = contexto.Todos.FirstOrDefault(x => x.Id == id);

            if (model == null) 
                return todo;

            model.Titulo = todo.Titulo;
            model.Pronta = todo.Pronta;

            contexto.Todos.Update(model);
            contexto.SaveChanges();

            return model;
        }

        [HttpDelete("/{id:int}")]
        public TodoModel Delete([FromRoute] int id, [FromServices] AppDBContext contexto) {
            var model = contexto.Todos.FirstOrDefault(x => x.Id == id);

            contexto.Todos.Remove(model);
            contexto.SaveChanges();

            return model;
        }
    }
}