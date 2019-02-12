using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    /// <summary>
    /// 登录用的视图模型
    /// </summary>
    public class LoginViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
