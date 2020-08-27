using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Contoso.Order
{
    public static partial class DistributeOrder
    {
        [FunctionName("DistributeOrderToCRM")]
        public static void DistributeOrderToCRM(
            [ServiceBusTrigger("orders", "crm", Connection = "ServiceBusConnection")]string body,
            [ServiceBus("q.orders.crm", Connection = "ServiceBusConnection")] out string targetMessage, 
            ILogger log)
        {
            targetMessage = null;
            if (!string.IsNullOrEmpty(body) && body.Contains("CRM"))
            {
                targetMessage = body;
            }

            log.LogInformation($"C# ServiceBus topic trigger function processed message: {body}");
        }
    }
}
