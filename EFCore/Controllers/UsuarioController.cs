using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.DTO;
using EFCore.Interface.Services;
using EFCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _services;

        public UsuarioController(IUsuarioServices services)
        {
            _services = services;
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios =  _services.GetAll();
            return Ok(usuarios);
        }
        
        [HttpGet("ID/{id}")]
        [Authorize]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _services.GetById(id);
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] UsuarioDTO usuario)
        {
            return await _services.Create(usuario);
        }

        [HttpPut("ID/{id}")]
        [Authorize]
        public async Task<ActionResult<Usuario>> update([FromBody] UsuarioDTO usuario, int id)
        {
            return await _services.Update(usuario, id);
        }
        [HttpDelete("ID/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _services.Delete(id);
        }
    }
}
