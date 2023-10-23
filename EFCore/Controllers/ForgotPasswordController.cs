using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IForgotPasswordServices _services;
        
        public ForgotPasswordController(IForgotPasswordServices services)
        {
            _services = services;
        }
        
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var result = _services.ForgotPassword(email);
            if(result.Result == "Email not found")
            {
                return BadRequest(result.Result);
            }
            return Ok(result.Result);
        }
        
        [HttpPut("Token/{token}, Password/{password}")]
        public async Task<IActionResult> ResetPassword(string token, string password)
        {
            var result = _services.ResetPassword(token, password);
            if(result.Result == "Invalid token")
            {
                return BadRequest(result.Result);
            }
            return Ok(result.Result);
        }
    }
}
