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
        [FunctionName("PushOrderToSAP")]
        public static void PushOrderToSAP(
            [ServiceBusTrigger("q.orders.sap", Connection = "ServiceBusConnection")]string body, 
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {body}");
            
            var response = client.PostAsync("http://localhost:7071/api/mock", new StringContent(body)).Result;

            log.LogInformation("Status: {status}, Message: {message}", response.StatusCode, response.Content.ReadAsStringAsync().Result);
        }
    }
}