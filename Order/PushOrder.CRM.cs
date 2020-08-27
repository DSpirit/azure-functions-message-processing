using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Contoso.Order
{
    public static partial class PushOrder
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("PushOrderToCRM")]
        public static async Task PushOrderToCRM(
            [ServiceBusTrigger("q.orders.crm", Connection = "ServiceBusConnection")]string body, 
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {body}");

            var response = await client.PostAsync("http://localhost:7071/api/mock", new StringContent(body));

            log.LogInformation("Status: {status}, Message: {message}", response.StatusCode, response.Content.ReadAsStringAsync().Result);

        }
    }
}
