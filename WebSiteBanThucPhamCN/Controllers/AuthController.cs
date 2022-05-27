

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebSiteBanThucPhamCN.Models;
using WebSiteBanThucPhamCN.Services;

namespace WebSiteBanThucPhamCN.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        AccountSv accountSv = new AccountSv();
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]TblAccount acc)
        {
            
            if (acc == null)
                return BadRequest("Invalid client request");
            else {
                TblAccount account = accountSv.GetAccount(acc.Username);
                if(account == null) return BadRequest("Invalid client request");
                else
                if (acc.Username.Equals(account.Username)&& acc.Password.Equals(account.Password.ToString())&&account.Status==true && account.IsDeleted==false)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
                    var claims = new Claim[]
                    {
                         new Claim("AccId",account.AccId.ToString()),
                           new Claim("UserId",account.UserId.ToString()),
                          
                    };
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44376",
                    audience: "https://localhost:44376",
                     //  issuer: "http://tuanan-001-site1.etempurl.com",
                     //audience: "http://tuanan-001-site1.etempurl.com",
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCredentials

                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            }
            return Unauthorized();
        }
    }
}
