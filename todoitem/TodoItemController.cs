using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using TodoItem.Models;

namespace TodoItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private TodoItemService service;

        public TodoItemController(TodoItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<TodoItem> GetTodoItems()
        {

            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItemById(int id)
        {
            return service.GetById(id);
        }

        [HttpPost("")]
        public ActionResult<TodoItem> PostTodoItem(TodoItem model)
        {
            TodoItem todoItem = service.Create(model);

            return Created($"api/todoItem/{todoItem.Id}", todoItem);
        }

        [HttpPut("{id}")]
        public  TodoItem PutTodoItem(int id, TodoItem model)
        {

            return service.Change(id, model);
        }

        [HttpDelete("{id}")]
        public List<TodoItem> DeleteTodoItemById(int id)
        {


            return service.Delete(id);
        }
    }
}