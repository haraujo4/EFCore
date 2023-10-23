using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.DTO;
using EFCore.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioLoginController : ControllerBase
    {
        private readonly ILoginServices _services;

        public UsuarioLoginController(ILoginServices services)
        {
            _services = services;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO login)
        {
            if (login == null)
                return BadRequest();

            try
            {
                var result =  _services.GetById(login);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
