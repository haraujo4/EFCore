using EFCore.Models;

namespace EFCore.DTO;

public class UsuarioLoginDTO
{
    public Usuario Usuario { get; set; }
    public string Token { get; set; }
}