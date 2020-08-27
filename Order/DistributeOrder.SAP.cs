using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Contoso.Order
{
    public static partial class DistributeOrder
    {
        [FunctionName("DistributeOrderToSAP")]
        public static void DistributeOrderToSAP(
            [ServiceBusTrigger("orders", "sap", Connection = "ServiceBusConnection")]string body,
            [ServiceBus("q.orders.sap", Connection = "ServiceBusConnection")] out string targetMessage, 
            ILogger log)
        {
            targetMessage = null;
            if (!string.IsNullOrEmpty(body) && body.Contains("SAP"))
            {
                targetMessage = body;
            }

            log.LogInformation($"C# ServiceBus topic trigger function processed message: {body}");
        }
    }
}
