using DelegateDotNet.Entity;

namespace DelegateDotNet.ServiceAdapters;

public static class SMSServiceAdapter1
{
    public static bool SMSService(User user)
    {
        Console.WriteLine("Send Message With SMS");
        return true;
    }
}
