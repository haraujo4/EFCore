using EFCore.Context;
using EFCore.DTO;
using EFCore.Interface.Repository;
using EFCore.Models;

namespace EFCore.Repository;

public class UsuarioRepository:IUsuarioRepository
{
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Usuario> GetAll()
    {
        var result =  _context.Usuarios.ToList();
        return result;
    }

    public Usuario GetById(int id)
    {
        var result = _context.Usuarios.Find(id);
        return result;
    }

    public async Task<Usuario> Create(Usuario usuario)
    {
        var user = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);
        if (user != null)
            return null;
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> Update(UsuarioDTO usuario, int id)
    {
        var result = await _context.Usuarios.FindAsync(id);
        if (result == null)
            return null;
        
        result.Nome = usuario.Nome;
        result.Email = usuario.Email;
        result.Senha = usuario.Senha;
        result.Status = usuario.Status;
        
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _context.Usuarios.FindAsync(id);
        if (result == null)
            return false;
        
        _context.Usuarios.Remove(result);
        await _context.SaveChangesAsync();
        return true;
    }
}