using AutoMapper;
using EFCore.DTO;
using EFCore.Helpers;
using EFCore.Interface.Repository;
using EFCore.Interface.Services;
using EFCore.Models;

namespace EFCore.Services;

public class UsuarioServices:IUsuarioServices
{
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;

    public UsuarioServices(IUsuarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public IEnumerable<Usuario> GetAll()
    {
        return _repository.GetAll();
    }

    public Usuario GetById(int id)
    {
        return _repository.GetById(id);
    }

    public async Task<Usuario> Create(UsuarioDTO usuario)
    {
        var HashedPassword = PasswordHash.GetHashCode(usuario.Senha);
        var model = _mapper.Map<Usuario>(usuario);
        model.Senha = HashedPassword;
        return await _repository.Create(model);
    }

    public async Task<Usuario> Update(UsuarioDTO usuario, int id)
    {
        return await _repository.Update(usuario, id);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.Delete(id);
    }
}