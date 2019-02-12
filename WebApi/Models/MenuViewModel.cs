using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class MenuViewModel
    {
        public string MenuId { get; set; }

        public string MenuName { get; set; }

        public string ParentId { get; set; }

        public string IconClass { get; set; }

        public string RouteName { get; set; }

        public List<MenuViewModel> Children { get; set; }
    }
}
