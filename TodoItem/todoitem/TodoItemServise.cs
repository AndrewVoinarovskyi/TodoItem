using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoItem
{
    public class TodoItemService
    {
        private List<TodoItem> todoItems = new List<TodoItem> {
        new TodoItem() { Id = 1, Title = "Implement read" },
        new TodoItem() { Id = 2, Title = "Implement create" }
        };
        private int lastId = 2;

        public List<TodoItem> GetAll()
        {
            return todoItems;
        }

        public TodoItem Create(TodoItem item)
        {
            item.Id = ++lastId;
            todoItems.Add(item);
            return item;
        }

        public TodoItem GetById(int id)
        {
            foreach (TodoItem item in todoItems)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        internal TodoItem Change(int id, TodoItem model)
        {
            foreach (TodoItem item in todoItems)
            {
                if(item.Id == id)
                {
                    item.Title = model.Title;
                    item.Description = model.Description;
                    item.DueDate = model.DueDate;
                    item.Done = model.Done;
                    return item;
                }
            }
            return null;
        }

        internal List<TodoItem> Delete(int id)
        {
            foreach (TodoItem item in todoItems)
            {
                if(item.Id == id)
                {
                    todoItems.Remove(item);
                }
            }
            return todoItems;
        }
    }
}