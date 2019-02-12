using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    /// <summary>
    /// Vue路由类
    /// </summary>
    public class RouteViewModel
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public string Component { get; set; }

        public MyMeta Meta { get; set; }

        public List<RouteViewModel> Children { get; set; }
    }

    public class MyMeta //路由里的自定义数据
    {
        /// <summary>
        /// 是否要身份认证
        /// </summary>
        public bool RequireAuth { get; set; } = true;

        public string MenuId { get; set; }
    }
}
