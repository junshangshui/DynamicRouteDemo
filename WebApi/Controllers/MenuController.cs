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
    [Authorize] // 要求身份认证
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("Menus")]
        public IActionResult GetMenus()
        {
            var menus = _menuService.GetTestMenus();
            return Ok(new { menus });
        }

        //[HttpGet("RoutersAndMenus")]
        //public IActionResult GetRoutersAndMenus()
        //{
        //    var routersAndMenus = _menuService.GetRoutersAndMenus();
        //    return Ok(new { routers = routersAndMenus.Item2, menus = routersAndMenus.Item1});
        //}

        [HttpPost("AddLiShi")]
        public IActionResult AddLiShi()
        {
            _menuService.AddLiShi();
            return Ok();
        }

        [HttpPost("AddYinYuFanYi")]
        public IActionResult AddYinYuFanYi()
        {
            _menuService.AddYinYuFanYi();
            return Ok();
        }
    }
}
