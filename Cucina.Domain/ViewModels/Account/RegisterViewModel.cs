namespace Cucina.Core.ViewModels.Account;

public class RegisterViewModel
{
    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? RePassword { get; set; }
}

public enum RegisterResult
{
    Success,
    EmailExists
}