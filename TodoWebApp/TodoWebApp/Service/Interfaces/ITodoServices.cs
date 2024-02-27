using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoWebApp.Models;

namespace TodoWebApp.Service.Interfaces
{
    public interface ITodoServices
    {
       // List<Todo> GetAllTodos();
        //List<Todo> AddTodos(Todo todo);
        Task<List<Todo>> GetAllTodosAsync();
        Task<List<Todo>> GetTodoAsync(int id);
        Task<List<Todo>> CreateTodoAsync(Todo todo);
        Task<List<Todo>> UpdateTodoAsync(Todo todo);
        Task<List<Todo>> DeleteTodoAsync(int id);
    }
}
