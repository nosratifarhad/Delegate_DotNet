
internal class Program
{
    public delegate string SendMessage();

    // for test :)))))))))

    private static void Main(string[] args)
    {
        string type = "mail";

        switch (type)
        {
            case "mail":
                Start(Email);
                break;
            case "sms":
                Start(SMS);
                break;

            default:
                Start(Email);
                break;
        }

        Console.ReadKey();
    }


    public static string Start(SendMessage test)
    {
        test();
        Console.WriteLine("Start");
        return "Start";
    }

    public static string SMS()
    {
        Console.WriteLine("Send with sms");
        return "Send with sms";
    }

    public static string Email()
    {
        Console.WriteLine("Send with mail");
        return "Send with mail";
    }



}