using System;
using todoanderson.Functions.Functions;
using todoanderson.Test.Helpers;
using Xunit;

namespace todoanderson.Test.Test{
    public class ScheduledFunctionTest{
        [Fact]
        public void ScheduledFunction_Should_Log_Message(){
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreatedLogger(LoggerTypes.List);

            ScheduledFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];

            Assert.Contains("Deletin completed", message);
        }
    }
}
