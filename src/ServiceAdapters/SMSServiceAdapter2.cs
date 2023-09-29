using DelegateDotNet.Entity;

namespace DelegateDotNet.ServiceAdapters;

public static class SMSServiceAdapter2
{
    public static void SMSService2(User user)
    {
        Console.WriteLine("Send Message With SMS");
    }
}
