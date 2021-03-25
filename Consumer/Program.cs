using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        private const string ehubNamespaceConnectionString = "";
        private const string eventHubName = "";
        private const string blobStorageConnectionString = "";
        private const string blobContainerName = "";

        static async Task Main(string[] args)
        {
            // Read from the default consumer group: $Default
            Console.WriteLine("Registering EventProcessor...");

            var eventProcessorHost = new EventProcessorHost(
                eventHubName,
                PartitionReceiver.DefaultConsumerGroupName,
                ehubNamespaceConnectionString,
                blobStorageConnectionString,
                blobContainerName);

            // Registers the Event Processor Host and starts receiving messages
            await eventProcessorHost.RegisterEventProcessorAsync<EventProcessor>();

            Console.WriteLine("Receiving. Press ENTER to stop worker.");
            Console.ReadLine();

            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
            Console.ReadKey();
        }
    }
}
