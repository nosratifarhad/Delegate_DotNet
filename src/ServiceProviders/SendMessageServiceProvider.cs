using DelegateDotNet.Entity;
using DelegateDotNet.ServiceAdapters;

namespace DelegateDotNet.ServiceProviders;

public static class SendMessageServiceProvider
{

    #region [ Delegate Customize Method ]

    public delegate bool SendMessageDelegate(User user);

    public static bool SendMessage(SendMessageDelegate delegateMethod, User user)
    {
        Console.WriteLine("Send Message With Method Customize");

        delegateMethod(user);

        return true;
    }

    public static void CustomizeMethod(User user)
    {
        switch (user.Type)
        {
            case SendType.EMail:
                SendMessage(EmailServiceAdapter1.EmailService1, user);
                break;

            case SendType.Sms:
                SendMessage(SMSServiceAdapter1.SMSService, user);
                break;

            case SendType.None:
                SendMessage(bool (User user) =>
                {
                    Console.WriteLine("SSend Message With SMS");
                    return true;
                }, user);
                break;

            default:
                var rere = static bool (User user) => user.Id == 1;
                rere.Invoke(user);
                break;
        }
    }

    #endregion [ Delegate Customize Method ]

    #region [ Delegate Func Method ]

    public static bool StartFuncMethod(Func<User, bool> delegateMethod, User user)
    {
        delegateMethod(user);
        Console.WriteLine("Start");
        return true;
    }

    public static void FuncMethod(User user)
    {
        switch (user.Type)
        {
            case SendType.EMail:
                StartFuncMethod(EmailServiceAdapter1.EmailService1, user);
                break;

            case SendType.Sms:
                StartFuncMethod(SMSServiceAdapter1.SMSService, user);
                break;
            case SendType.None:
                SendMessage(bool (User user) =>
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

    #endregion [ Delegate Func Method ]

    #region [ Delegate Action Method ]

    public static bool StartActionMethod(Action<User> delegateMethod, User user)
    {
        delegateMethod(user);
        Console.WriteLine("Start");
        return true;
    }

    public static void ActionMethod(User user)
    {
        switch (user.Type)
        {
            case SendType.EMail:
                StartActionMethod(EmailServiceAdapter2.EmailService2, user);
                break;

            case SendType.Sms:
                StartActionMethod(SMSServiceAdapter2.SMSService2, user);
                break;

            case SendType.None:
            default:
                StartActionMethod((User user) =>
                {
                    Console.WriteLine("Send with sms");
                }, user);
                break;
        }
    }

    #endregion [ Delegate Action Method ]

}
