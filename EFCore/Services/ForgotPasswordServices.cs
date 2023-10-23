using AutoMapper;
using EFCore.DTO;
using EFCore.Helpers;
using EFCore.Interface.Repository;
using EFCore.Interface.Services;
using EFCore.Models;

namespace EFCore.Services;

public class ForgotPasswordServices:IForgotPasswordServices
{
    private readonly ILoginRepository _loginRepository;
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;
    private string BASEURL = "https://localhost:5165/api/ResetPassword";
    
    public ForgotPasswordServices(ILoginRepository loginRepository, IUsuarioRepository repository, IMapper mapper)
    {
        _loginRepository = loginRepository;
        _repository = repository;
        _mapper = mapper;
    }
    
    public Task<string> ForgotPassword(string email)
    {
        var user = _loginRepository.GetById(email);
        if (user == null)
        {
            return Task.FromResult("Email not found");
        }

        var token = Jwt.GetToken(user);
        var link = BASEURL  + "?token=" + token;
        var subject = "Reset Password";
        var body = "Para resetar sua senha, informe o Token a seguir: " + token + " ou clique no link a seguir: " + link;
        SendEmail.SendNewMail(email,subject, body);
        return Task.FromResult("Email sent");
    }

    public async Task<string> ResetPassword(string token, string password)
    {
        var user = Jwt.ValidateToken(token);
        if (user == null)
        {
            return await Task.FromResult("Invalid token");
        }
        var usuario = _repository.GetById(int.Parse(user));
        var usarioMapper = _mapper.Map<UsuarioDTO>(usuario);
        usarioMapper.Senha = PasswordHash.GetHashCode(password);
        await _repository.Update(usarioMapper, usuario.Id);
        return await Task.FromResult("Password updated");
    }
}