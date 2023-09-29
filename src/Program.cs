using DelegateDotNet.Entity;
using DelegateDotNet.ServiceProviders;

internal class Program
{
    private static void Main(string[] args)
    {
        User user = new User()
        {
            Id = 1,
            Name = "farhad",
            Number = "09122222222",
            Type = SendType.EMail,
        };

        SendMessageServiceProvider.CustomizeMethod(user);

        SendMessageServiceProvider.FuncMethod(user);

        SendMessageServiceProvider.ActionMethod(user);

        Console.ReadKey();

    }
}