namespace EFCore.Interface.Services;

public interface IForgotPasswordServices
{
    Task<string> ForgotPassword(string email);
    Task<string> ResetPassword(string token, string password);
}