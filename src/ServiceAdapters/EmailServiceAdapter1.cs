using DelegateDotNet.Entity;

namespace DelegateDotNet.ServiceAdapters;

public static class EmailServiceAdapter1
{
    public static bool EmailService1(User user)
    {
        Console.WriteLine("Send Message With Mail");
        return true;
    }

}
