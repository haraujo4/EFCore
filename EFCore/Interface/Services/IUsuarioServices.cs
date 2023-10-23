using EFCore.DTO;
using EFCore.Models;

namespace EFCore.Interface.Services;

public interface IUsuarioServices
{
    IEnumerable<Usuario> GetAll();
    Usuario GetById(int id);
    Task<Usuario> Create(UsuarioDTO usuario);
    Task<Usuario> Update(UsuarioDTO usuario, int id);
    Task<bool> Delete(int id);
}