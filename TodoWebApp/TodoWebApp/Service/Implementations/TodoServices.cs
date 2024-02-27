using TodoWebApp.Service.Interfaces;
using TodoWebApp.Repository.Interfaces;
using TodoWebApp.Models;
using TodoWebApp.Repository.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebApp.Service.Implementations
{
    public class TodoServices: ITodoServices
    {
        private readonly ITodoRepository _todoRepo;
        public TodoServices(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
            
        }
       
        public List<Todo> GetAllTodos()
        {
            return _todoRepo.GetAllTodos();
        }
        public Task<List<Todo>>GetAllTodosAsync()
        {
            return _todoRepo.GetAllTodosAsync();
        }
        public Task<List<Todo>> GetTodoAsync(int id)
        {
            return _todoRepo.GetTodoAsync(id);
        }
        public Task<List<Todo>> CreateTodoAsync(Todo todo)
        {
            return _todoRepo.CreateTodoAsync(todo);
        }
        public Task<List<Todo>> DeleteTodoAsync(int id)
        {
            return _todoRepo.DeleteTodoAsync(id);
        }
        public Task<List<Todo>> UpdateTodoAsync(Todo todo)
        {
            return _todoRepo.UpdateTodoAsync(todo);
        }










    }
}
