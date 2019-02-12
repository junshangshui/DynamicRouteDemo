using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class MenuInfo
    {
        public string MenuId { get; set; }

        public string MenuName { get; set; }

        public string ParentId { get; set; }

        public string IconClass { get; set; }

        public int MenuDeep { get; set; }//层级深度

        public string RoutePath { get; set; }

        public string RouteParentPath { get; set; }

        //public string RouteName { get; set; }

        public bool RequireAuth { get; set; } = true;
    }
}
