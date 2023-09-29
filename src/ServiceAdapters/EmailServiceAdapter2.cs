using DelegateDotNet.Entity;

namespace DelegateDotNet.ServiceAdapters;

public static class EmailServiceAdapter2
{
    public static void EmailService2(User user)
    {
        Console.WriteLine("Send Message With Mail");
    }
}
