using System;
namespace FactoryPatternDemo
{
    public class EmailNotification : INotification
    {
        public void sendMessage(string message)
        {
            Console.WriteLine($"The message sent through Email is:{message}");
        }
    }
}
