using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Contoso
{
    public static class Run
    {
        [FunctionName("TriggerSample")]
        public static async Task<IActionResult> TriggerSample(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [ServiceBus("orders", Connection = "ServiceBusConnection")] ICollector<string> messages, 
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            messages.Add(await new StreamReader(req.Body).ReadToEndAsync());

            return new OkResult();
        }
    }
}
