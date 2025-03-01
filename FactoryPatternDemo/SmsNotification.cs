using System;
namespace FactoryPatternDemo
{
    public class SmsNotification : INotification
    {
        public void sendMessage(string message)
        {
            Console.WriteLine($"The message sent through Sms Notification is:{message}");
        }
    }
}

