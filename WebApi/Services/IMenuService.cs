using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IMenuService
    {
        List<MenuInfo> GetTestMenus();

        //Tuple<List<MenuViewModel>, List<RouteViewModel>> GetRoutersAndMenus();

        void AddLiShi();

        //添加：英语翻译
        void AddYinYuFanYi();
    }
}
