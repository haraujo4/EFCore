using EFCore.Models;

namespace EFCore.Interface.Repository;

public interface ILoginRepository
{
    Usuario GetById(string email);
}