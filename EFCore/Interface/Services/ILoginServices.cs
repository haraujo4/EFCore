using EFCore.DTO;
using EFCore.Models;

namespace EFCore.Interface.Services;

public interface ILoginServices
{
     UsuarioLoginDTO GetById(LoginDTO login);
}