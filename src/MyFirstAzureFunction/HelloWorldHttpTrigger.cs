using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsUniversity.Demo
{
    public static class HelloWorldHttpTrigger
    {
        [FunctionName(nameof(HelloWorldHttpTrigger))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Function, 
                nameof(HttpMethods.Get), 
                nameof(HttpMethods.Post), 
                Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = default;
            if (req.Method.Method == HttpMethods.Get)
            {
                var collection = req.RequestUri.ParseQueryString();
                name = collection["name"];
            }
            else if (req.Method.Method == HttpMethods.Post)
            {
                var person = await req.Content.ReadAsAsync<Person>();
                name = person.Name;
            }

            ObjectResult result;
            if(string.IsNullOrEmpty(name))
            {
                var failMessage = Environment.GetEnvironmentVariable("Message.Fail");
                result = new BadRequestObjectResult(failMessage);
            }
            else
            {
                var successMessage = Environment.GetEnvironmentVariable("Message.Success");
                var responseMessage = $"Hello, {name}. {successMessage}";
                result = new OkObjectResult(responseMessage);
            }

            return result;
        }
    }
}
