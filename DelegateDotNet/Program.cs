
using System.Xml.Linq;

internal class Program
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public string Type { get; set; }
    }

    public delegate bool SendMessage(User user);

    public static bool Start(SendMessage test, User user)
    {
        test(user);
        Console.WriteLine("Start");
        return true;
    }

    public static bool StartFunc(Func<User, bool> test, User user)
    {
        test(user);
        Console.WriteLine("Start");
        return true;
    }

    public static bool StartAction(Action<User> test, User user)
    {
        test(user);
        Console.WriteLine("Start");
        return true;
    }

    private static void Main(string[] args)
    {
        User user = new User()
        {
            Id = 1,
            Name = "UserName",
            Number = "09122222222",
            Type = "sms",
        };

        NewMethod(user);

        FuncMethod(user);

        ActionMethod(user);

        Console.ReadKey();

    }



    public static bool SMS(User user)
    {
        Console.WriteLine("Send with sms");
        return true;
    }

    public static bool Email(User user)
    {
        Console.WriteLine("Send with mail");
        return true;
    }

    public static void Sms(User user)
    {
        Console.WriteLine("Send with sms");
    }

    public static void email(User user)
    {
        Console.WriteLine("Send with mail");
    }

    private static void NewMethod(User user)
    {
        switch (user.Type)
        {
            case "mail":
                Start(Email, user);
                break;

            case "sms":
                Start(SMS, user);
                break;

            case "none":
                Start(bool (User user) =>
                {
                    Console.WriteLine("Send with sms");
                    return true;
                }, user);
                break;

            default:
                var rere = static bool (User user) => user.Id == 1;
                rere.Invoke(user);
                break;
        }
    }

    public static void FuncMethod(User user)
    {
        switch (user.Type)
        {
            case "mail":
                StartFunc(Email, user);
                break;

            case "sms":
                StartFunc(SMS, user);
                break;
            default:
                StartFunc(bool (User user) =>
                {
                    Console.WriteLine("Send with sms");
                    return true;
                }, user);
                break;
        }
    }

    public static void ActionMethod(User user)
    {
        switch (user.Type)
        {
            case "mail":
                StartAction(email, user);
                break;

            case "sms":
                StartAction(Sms, user);
                break;
            default:
                StartAction((User user) =>
                {
                    Console.WriteLine("Send with sms");
                }, user);
                break;
        }
    }

}