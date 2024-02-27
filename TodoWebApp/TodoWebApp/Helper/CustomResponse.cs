using TodoWebApp.Models;

namespace TodoWebApp.Helper
{
    public class CustomResponse
    {
        
            public int StatusCode { get; set; }
            public string StatusMessage { get; set; }

            public Todo todo { get; set; }

            public List<Todo> listTodo { get; set; }
        
    }
}
