using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.ServiceBus;
using System.Text;

/// <summary>
/// https://www.c-sharpcorner.com/article/how-to-send-read-messages-from-azure-service-bus-queues-using-azure/
/// </summary>

namespace AzureServiceBusWithAzureFunctions
{
    public static class SendMessage
    {
        [FunctionName("SendMessage")]
        [return: ServiceBus("recharge", EntityType.Queue)]
        public static async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("SendMessage function requested");
            string body = string.Empty;
            using (var reader = new StreamReader(req.Body, Encoding.UTF8))
            {
                body = await reader.ReadToEndAsync();
                log.LogInformation($"Message body : {body}");
            }
            log.LogInformation($"SendMessage processed.");
            return body;
        }

    }

    
}
