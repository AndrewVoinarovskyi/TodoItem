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
        TodoItemService TodoItemService { get; set; }

        public TodoItemController(TodoItemService service)
        {
            this.TodoItemService = service;
        }

        [HttpGet]
        public List<TodoItem> GetTodoItems()
        {

            return TodoItemService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItemById(int id)
        {
            return TodoItemService.GetById(id);
        }

        [HttpPost("")]
        public ActionResult<TodoItem> PostTodoItem(TodoItem model)
        {
            TodoItem todoItem = TodoItemService.Create(model);

            return Created($"api/todoItem/{todoItem.Id}", todoItem);
        }

        [HttpPut("{id}")]
        public  Task<IActionResult> PutTodoItem(int id, TodoItem model)
        {


            return null;
        }

        [HttpDelete("{id}")]
        public ActionResult<TodoItem> DeleteTodoItemById(int id)
        {


            return null;
        }
    }
}