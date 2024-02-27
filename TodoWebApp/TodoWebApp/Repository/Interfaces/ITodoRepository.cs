using TodoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebApp.Repository.Interfaces
{
    public interface ITodoRepository
    {
        //List<Todo> GetAllTodos();


        Task<List<Todo>> GetAllTodosAsync();
        Task<List<Todo>> GetTodoAsync(int id);
        Task<List<Todo>> CreateTodoAsync(Todo todo);
        Task<List<Todo>> DeleteTodoAsync(int id);
        Task<List<Todo>> UpdateTodoAsync(Todo todo);
        //public List<Todo> AddTodos(Todo todo);


    }
}
