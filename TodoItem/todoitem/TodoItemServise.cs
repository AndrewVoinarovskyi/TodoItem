using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoItem
{
    public class TodoItemService
    {
        List<TodoItem> todoItems = new List<TodoItem>() {
            new TodoItem{Id = 1, Title = "First todo"},
            new TodoItem{Id = 2, Title = "Second todo"},
        };
        private int lastId = 2;
        TodoItem todoItem;

        public List<TodoItem> GetAll()
        {
            return todoItems;
        }

        public TodoItem Create(TodoItem model)
        {
            TodoItem todoItem = new TodoItem
            {
                Id = ++lastId,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Done = model.Done,
            };

            todoItems.Add(todoItem);
            return todoItem;
        }

        public TodoItem GetById(int id)
        {
            foreach (TodoItem item in todoItems)
            {
                if(item.Id == id)
                {
                    todoItem = item;
                }
            }
            return todoItem;
        }
    }
}