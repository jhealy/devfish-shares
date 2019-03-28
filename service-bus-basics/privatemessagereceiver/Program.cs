using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace privatemessagereceiver
{
    class Program
    {

        const string m_ServiceBusConnectionString = @"insert-connection-string-here";
        const string m_QueueName = "salesmessages";
        static IQueueClient m_queueClient;

        static void Main(string[] args)
        {

            ReceiveSalesMessageAsync().GetAwaiter().GetResult();

        }

        static async Task ReceiveSalesMessageAsync()
        {

            // Create a Queue Client here
            m_queueClient = new QueueClient(m_ServiceBusConnectionString, m_QueueName);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after receiving all the messages.");
            Console.WriteLine("======================================================");

            RegisterMessageHandler();
        
            Console.Read();

            // Close the queue here
            await m_queueClient.CloseAsync();

        }

        static void RegisterMessageHandler()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            m_queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");

            long sentTicks;
            if (long.TryParse(Encoding.UTF8.GetString(message.Body), out sentTicks))
            {
                long nowTicks = DateTime.Now.Ticks;
                int ticksToMS = 10000;
                int mstofetch = (int)((nowTicks - sentTicks)/ticksToMS);
                double secstofetch = mstofetch / 1000.00;

                Console.WriteLine($"{(int)(nowTicks/ticksToMS)}:now - {(int)(sentTicks/ticksToMS)}:sent = {mstofetch}:ms {secstofetch}:seconds");
            }
            else
            {
                Console.WriteLine("Message was not in millisecond format.  Error.");
            }

            await m_queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }   
    }
}
