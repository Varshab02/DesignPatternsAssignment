using FactoryPatternDemo;

public class NotificationFactory
{
    public static INotification CreateNotification(string type)
    {
        INotification notification = null;
        if (type.ToLower() == "email")
        {
            notification = new EmailNotification();
        }
        else if (type.ToLower() == "sms")
        {
            notification = new SmsNotification();
        }
        else if (type.ToLower() == "push")
        {
            notification = new PushNotification();
        }
        return notification;
    }

}
