using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureServiceBusWithAzureFunctions
{
    public static class ReadMessageFromQueue
    {
        [FunctionName("ReadMessageFromQueue")]
        public static void Run([ServiceBusTrigger("recharge")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
