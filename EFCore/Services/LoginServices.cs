using EFCore.DTO;
using EFCore.Helpers;
using EFCore.Interface.Repository;
using EFCore.Interface.Services;

namespace EFCore.Services;

public class LoginServices:ILoginServices
{
    private readonly ILoginRepository _loginRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginServices(ILoginRepository loginRepository, IHttpContextAccessor httpContextAccessor)
    {
        _loginRepository = loginRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    public UsuarioLoginDTO GetById(LoginDTO login)
    {
        var usuario = _loginRepository.GetById(login.Usuario);
        if(!BCrypt.Net.BCrypt.Verify(login.Senha, usuario.Senha) || usuario.Status == true)
        {
            return null;
        }
        else
        {
            var token = Jwt.GetToken(usuario);
            string subject = "Olá, " + usuario.Nome + " seja bem vindo ao sistema";
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            string message = $"Um login foi realizado em sua conta no dia {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} a partir do endereço IP {ipAddress}.";

            SendEmail.SendNewMail(usuario.Email, subject, message);
            return new UsuarioLoginDTO
            {
                Usuario = usuario,
                Token = token
            };
        }
    }
}