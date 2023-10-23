using EFCore.Context;
using EFCore.Interface.Repository;
using EFCore.Models;

namespace EFCore.Repository;

public class LoginRepository:ILoginRepository
{
    private readonly DataContext _context;

    public LoginRepository(DataContext context)
    {
        _context = context;
    }
    public Usuario GetById(string email)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Email == email);
    }
}