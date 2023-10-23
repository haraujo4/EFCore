using EFCore.DTO;
using EFCore.Models;

namespace EFCore.Interface.Repository;

public interface IUsuarioRepository
{
    IEnumerable<Usuario> GetAll();
    Usuario GetById(int id);
    Task<Usuario> Create(Usuario usuario);
    Task<Usuario> Update(UsuarioDTO usuario, int id);
    Task<bool> Delete(int id);
}