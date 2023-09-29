namespace DelegateDotNet.Entity;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Number { get; set; }

    public SendType Type { get; set; }
}

public enum SendType
{
    None = 0,
    EMail = 1,
    Sms = 2,
}
