using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using todoanderson.Common.Models;
using todoanderson.Functions.Functions;
using todoanderson.Test.Helpers;
using Xunit;

namespace todoanderson.Test.Test{
    public class TodoApiTest{
        private readonly ILogger logger = TestFactory.CreatedLogger();
        [Fact]
        public async void CreateTodo_Should_Return_200(){
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreatedHttpRequest(todoRequest);

            var response = await TodoApi.CreateTodo(request, mockTodos, logger);

            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
        [Fact]
        public async void UpDateTodo_Should_Return_200(){
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreatedHttpRequest(todoId, todoRequest);

            var response = await TodoApi.UpdateTodo(request, mockTodos, todoId.ToString(), logger);

            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
