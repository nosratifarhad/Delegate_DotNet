# Delegate
 We have three types of delegate here.
### 1- customize delegate .
### 2- Func delegate .
### 3- Action delegate .

# Details :

### You should have multiple separate services with different implementations .
## Services with output models and without output models Like below : 
```csharp
// With Output
public static bool EmailService1(User user)
{
    Console.WriteLine("Send Message With Mail");
    return true;
}
public static bool SMSService(User user)
{
    Console.WriteLine("Send Message With SMS");
    return true;
}

// WithOut Output
public static void EmailService2(User user)
{
    Console.WriteLine("Send Message With Mail");
}
public static void SMSService2(User user)
{
    Console.WriteLine("Send Message With SMS");
}
```
## 1- customize delegate :
### Create delegate signature :
```csharp
public delegate bool SendMessageDelegate(User user);
```
### And implementa Method For Call DelegateMethod Like below : 
```csharp
public static bool SendMessage(SendMessageDelegate delegateMethod, User user)
{
    Console.WriteLine("Send Message With Method Customize");

    delegateMethod(user);

    return true;
}
```
### Now, to use one of the services, you need a factory or service provider Like below :
```csharp
public static void CustomizeMethod(User user)
{
    switch (user.Type)
    {
        case SendType.Mail:
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
```
### How to Use :
```csharp
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

    Console.ReadKey();
}
```
## 2- Func delegate :
### And implementa Method For Call DelegateMethod Like below : 
```csharp
public static bool StartFuncMethod(Func<User, bool> delegateMethod, User user)
{
    delegateMethod(user);
    Console.WriteLine("Start");
    return true;
}
```
### Now, to use one of the services, you need a factory or service provider Like below :
```csharp
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
```
### How to Use :
```csharp
private static void Main(string[] args)
{
    User user = new User()
    {
        Id = 1,
        Name = "farhad",
        Number = "09122222222",
        Type = SendType.EMail,
    };

    SendMessageServiceProvider.FuncMethod(user);

    Console.ReadKey();
}
```
## 3- Action delegate .
### And implementa Method For Call DelegateMethod Like below : 
```csharp
public static bool StartActionMethod(Action<User> delegateMethod, User user)
{
    delegateMethod(user);
    Console.WriteLine("Start");
    return true;
}
```
### Now, to use one of the services, you need a factory or service provider Like below :
```csharp
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
```
### How to Use :
```csharp
private static void Main(string[] args)
{
    User user = new User()
    {
        Id = 1,
        Name = "farhad",
        Number = "09122222222",
        Type = SendType.EMail,
    };

    SendMessageServiceProvider.ActionMethod(user);

    Console.ReadKey();
}
```
