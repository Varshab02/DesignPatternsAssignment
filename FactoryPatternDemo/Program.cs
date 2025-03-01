using FactoryPatternDemo;

class Program
{
    static void Main()
    {
        Console.Write("Enter Notification Type\n 1.Email\n 2.SMS\n 3.Push ");
        string type = Console.ReadLine();

        try
        {
            INotification notification = NotificationFactory.CreateNotification(type);
            notification.sendMessage("Hello Welcome Here.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
