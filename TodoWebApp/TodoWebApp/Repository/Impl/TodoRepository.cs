using System.Data.SqlClient;
using System.Data;
using TodoWebApp.Models;
using TodoWebApp.Repository.Interfaces;
using TodoWebApp.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using Microsoft.VisualBasic;
using Microsoft.IdentityModel.Tokens;
using TodoWebApp.Service.Interfaces;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Identity.Client;

namespace TodoWebApp.Repository.Implementations
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IConfiguration _configuration;
        public TodoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      /*  public List<Todo> GetAllTodos()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            SqlDataAdapter da = new SqlDataAdapter("Select * from todoTBL", connection);
            DataTable dt = new DataTable();
            List<Todo> listtodo = new List<Todo>();

            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int index = 0; index < dt.Rows.Count; ++index)
                {
                    Todo todo = new Todo();
                    todo.Id = Convert.ToInt32(dt.Rows[index]["Id"]);
                    todo.Title = Convert.ToString(dt.Rows[index]["Title"]);
                    todo.Descriptions = Convert.ToString(dt.Rows[index]["Descriptions"]);
                    todo.DueDate = Convert.ToDateTime(dt.Rows[index]["DueDate"]);
                    todo.CurrentDate = Convert.ToDateTime(dt.Rows[index]["CurrentDate"]);
                    todo.isComplete = Convert.ToInt32(dt.Rows[index]["isComplete"]);
                    listtodo.Add(todo);
                }



            }
            return listtodo;
        }
      */


        public async Task<List<Todo>> GetAllTodosAsync()
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            var data = await conn.QueryAsync<Todo>("Select * from todoTBL");
            return data.ToList();
        }
        public async Task<List<Todo>> GetTodoAsync(int id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            var data = await conn.QueryAsync<Todo>("Select * from todoTBL where id = @Id", new {Id = id});
            return data.ToList();
        }
        public async Task<List<Todo>> CreateTodoAsync(Todo todo)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            await conn.ExecuteAsync("insert into todoTBL(Title,Descriptions,DueDate,CurrentDate,isComplete) values(@Title,@Descriptions,@DueDate,@CurrentDate,@isComplete)",todo);
            return await GetAllTodosAsync();




        }
        
        public async Task<List<Todo>> DeleteTodoAsync(int id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            await conn.ExecuteAsync("Delete from todoTBl where id = @Id", new {Id = id});
            return await GetAllTodosAsync();

        }

        public async Task<List<Todo>> UpdateTodoAsync(Todo todo)
        {
          // CustomResponse response = new CustomResponse();
            using var conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            int rowsAffected = await conn.ExecuteAsync("update todoTBL set Title = @Title, descriptions = @Descriptions, duedate = @DueDate, currentdate = @CurrentDate, isComplete = @IsComplete where id = @Id", todo);

            return await GetAllTodosAsync();


        }


    }

    
}