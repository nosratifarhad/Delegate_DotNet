
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

    private static void Main(string[] args)
    {
        User user = new User()
        {
            Id = 1,
            Name = "UserName",
            Number = "09122222222",
            Type = "sms",
        };

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
}