using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoItem
{
    public class TodoItemService
    {
        private List<List<TodoItem>> todoLists = new List<List<TodoItem>> {
            new List<TodoItem> {
                new TodoItem() { Id = 1, Title = "Implement read" },
                new TodoItem() { Id = 2, Title = "Implement create" }
            },
            new List<TodoItem> {
                new TodoItem() { Id = 1, Title = "First in second" },
                new TodoItem() { Id = 2, Title = "Second in second" }
            }
        };


        private List<TodoItem> todoItems;

        // private List<TodoItem> todoItems = new List<TodoItem> {
        // new TodoItem() { Id = 1, Title = "Implement read" },
        // new TodoItem() { Id = 2, Title = "Implement create" }
        // };

        
        private int lastId = 2;

        public List<TodoItem> GetAll(int listId)
        {
            
            return todoLists[listId - 1];
        }

        public TodoItem Create(int listId, TodoItem item)
        {
            todoItems = todoLists[listId - 1];
            item.Id = ++lastId;
            todoItems.Add(item);
            return item;
        }

        public TodoItem GetById(int listId, int id)
        {
            todoItems = todoLists[listId - 1];
            foreach (TodoItem item in todoItems)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        internal TodoItem Change(int listId, int id, TodoItem model)
        {
            todoItems = todoLists[listId - 1];
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

        internal List<TodoItem> Delete(int listId, int id)
        {
            todoItems = todoLists[listId - 1];
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