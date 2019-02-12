using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IAdminLoginService _adminLoginService;

        public AdminController(IOptions<JwtSettings> options, IAdminLoginService adminLoginService)
        {
            _jwtSettings = options.Value;
            _adminLoginService = adminLoginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel data)
        {
            LoginViewModel model = data;

            if (model == null)
            {
                return new JsonResult(new { IsLoginSuccess = false, Message = "登录出错" });
            }

            var adminUser = _adminLoginService.FindByUsername(model.UserName);
            if (adminUser == null)
            {
                return new JsonResult(new { IsLoginSuccess = false, Message = "用户名不存在" });
            }

            if (!_adminLoginService.ValidateAdminUser(adminUser, model.Password))
            {
                return new JsonResult(new { IsLoginSuccess = false, Message = "密码不正确" });
            }

            var claims = new Claim[]
            {
                new Claim("UserId", adminUser.UserId),
                new Claim("UserName", adminUser.UserName),
                new Claim("UserRole","admin"),
                //new Claim("SuperAdminClaim","111")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(11),//暂时改为1分钟，方便测试
                credentials
            );
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return new JsonResult(new { IsLoginSuccess = true, Message = tokenStr });
        }

        [HttpPost("logout")]
        [Authorize] // 要求身份认证
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}