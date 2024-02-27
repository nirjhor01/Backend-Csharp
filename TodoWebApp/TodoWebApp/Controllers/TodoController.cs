using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TodoWebApp.Repository.Implementations;
using TodoWebApp.Service.Interfaces;
using TodoWebApp.Service.Implementations;

namespace TodoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices _services;

        public TodoController(ITodoServices todoServices)
        {
            _services = todoServices;
        }
        /*
        [HttpGet]
        [Route("GetAllTodos")]
        public List<Todo> GetAllTodos()
        {
            return _services.GetAllTodos();
        }
        */
        [HttpGet]
        [Route("GetAllTodosAsync")]
        public Task<List<Todo>> GetAllTodosAsync()
        {
            return _services.GetAllTodosAsync();
        }
        [HttpGet]
        [Route("GetTodoAsync")]
        public Task<List<Todo>> GetTodoAsync(int id)
        {
            return _services.GetTodoAsync(id);
        }
        [HttpPut]
        [Route("UpdateTodooAsync")]
        public Task<List<Todo>> UpdateTodoAsync(Todo todo)
        {
            return _services.UpdateTodoAsync(todo);
        }
        [HttpPost]
        [Route("CreateTodoAsync")]
        public Task<List<Todo>> CreateTodoAsync(Todo todo)
        {
            return _services.CreateTodoAsync(todo);
        }
        [HttpDelete]
        [Route("DeleteTodoAsync")]
        public Task<List<Todo>> DeleteTodoAsync(int id)
        {
            return _services.DeleteTodoAsync(id);
        }
        /*
         [HttpPost]
         [Route("AddTodo")]
         public Response AddTodo(Todo todo)
         {
             SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
             Response response = new Response();
             DAL dal = new DAL();
             response = dal.AddTodo(connection, todo);
             return response;
         }


         [HttpDelete]
         [Route("DeleteTodo/{id}")]
         public Response DeleteTodo(int id)
         {
             SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
             //SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
             Response response = new Response();
             DAL dal = new DAL();
             response = dal.DeleteTodo(connection, id);
             return response;

         }

         [HttpPut]
         [Route("UpdateTodo")]
         public Response UpdateTodo(Todo todo)
         {
             SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
             Response response = new Response();
             DAL dal = new DAL();
             response = dal.UpdateTodo(connection, todo);
             return response;

         }
        */

    }
}
