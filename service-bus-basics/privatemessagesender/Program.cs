using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace privatemessagesender
{
    class Program
    {

        const string m_ServiceBusConnectionString = @"insert-connection-string-here";
        const string m_QueueName = "salesmessages";
        static IQueueClient m_queueClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Sending a message to the Sales Messages queue...");

            SendSalesMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine("Message was sent successfully.");
        }

        static async Task SendSalesMessageAsync()
        {
            // Create a Queue Client here
            m_queueClient = new QueueClient(m_ServiceBusConnectionString, m_QueueName);

            // Send messages.
            try
            {
                for ( int ii=0; ii<10; ii++ )
                {
                    // Create and send a message here
                    // string messageBody = $"$10,000 order for bicycle parts from retailer Adventure Works.";              
                    long nowTicks = DateTime.Now.Ticks;
                    string messageBody = nowTicks.ToString();
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    Console.WriteLine($"Sending message: {messageBody}");
                    await m_queueClient.SendAsync(message);
                    Thread.Sleep(2000);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            // Close the connection to the queue here
            await m_queueClient.CloseAsync();
        }
    }
}
