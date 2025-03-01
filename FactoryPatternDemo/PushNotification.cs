using System;
namespace FactoryPatternDemo
{
    public class PushNotification : INotification
    {
        public void sendMessage(string message)
        {
            Console.WriteLine($"The message sent through Push Notification is:{message}");
        }
    }
}
