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
    public class TodoListController : ControllerBase
    {
        private TodoItemService service;
        public TodoListController(TodoItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<TodoItem> GetTodoItems(int listId)
        {

            return service.GetAll(listId);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItemById(int listId, int id)
        {
            return service.GetById(listId, id);
        }

        [HttpPost("")]
        public ActionResult<TodoItem> PostTodoItem(int listId, TodoItem model)
        {
            TodoItem todoItem = service.Create(listId, model);

            return Created($"api/todoItem/{todoItem.Id}", todoItem);
        }

        [HttpPut("{id}")]
        public  TodoItem PutTodoItem(int listId, int id, TodoItem model)
        {

            return service.Change(listId, id, model);
        }

        [HttpDelete("{id}")]
        public List<TodoItem> DeleteTodoItemById(int listId, int id)
        {


            return service.Delete(listId, id);
        }
    }
}