using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class MenuService : IMenuService
    {
        // 左侧显示的菜单的最大深度（这里值为3，即下面的“英语语法”和"英语口语"这样的深度大于3的不显示在主页的左侧菜单栏）
        //private const int LeftMenu_MaxDeep = 3;

        public List<MenuInfo> GetTestMenus()
        {
            // 假设从数据库取出了如下的菜单信息
            List<MenuInfo> menus = new List<MenuInfo>()
            {
                new MenuInfo{MenuId="1", MenuName="学习管理", ParentId="", MenuDeep=1, IconClass="el-icon-location", RoutePath=""},
                new MenuInfo{MenuId="1-1", MenuName="文科", ParentId="1", MenuDeep=2, IconClass="", RoutePath=""},
                new MenuInfo{MenuId="1-1-1", MenuName="语文", ParentId="1-1", MenuDeep=3, IconClass="", RoutePath="/YuWen"},
                new MenuInfo{MenuId="1-1-2", MenuName="英语", ParentId="1-1", MenuDeep=3, IconClass="", RoutePath="/YingYu"},
                new MenuInfo{MenuId="1-1-2-1", MenuName="英语语法", ParentId="1-1-2", MenuDeep=4, RoutePath="/YingYuYuFa", RouteParentPath="/YingYu"},
                new MenuInfo{MenuId="1-1-2-2", MenuName="英语口语", ParentId="1-1-2", MenuDeep=4, RoutePath=""},
                new MenuInfo{MenuId="1-1-2-2-a", MenuName="早间口语", ParentId="1-1-2-2", MenuDeep=5, RoutePath="/YingYuKouYuLianXi", RouteParentPath="/YingYu"},
                new MenuInfo{MenuId="1-1-2-2-b", MenuName="晚上口语", ParentId="1-1-2-2", MenuDeep=5, RoutePath="/YingYuKouYuLianXi", RouteParentPath="/YingYu"},
                new MenuInfo{MenuId="1-2", MenuName="理科", ParentId="1", MenuDeep=2, IconClass="", RoutePath=""},
                new MenuInfo{MenuId="1-2-1", MenuName="数学", ParentId="1-2", MenuDeep=3, IconClass="", RoutePath="/ShuXue"},
                new MenuInfo{MenuId="1-2-2", MenuName="物理", ParentId="1-2", MenuDeep=3, IconClass="", RoutePath="/WuLi"},
                new MenuInfo{MenuId="2", MenuName="角色管理", ParentId="", MenuDeep=1, IconClass="el-icon-menu", RoutePath="/RoleManage"},
                new MenuInfo{MenuId="3", MenuName="用户管理", ParentId="", MenuDeep=1, IconClass="el-icon-setting", RoutePath="/UserManage"}
            };

            if(TempObject.IsAddLiShi)
            {
                menus.Add(new MenuInfo { MenuId = "1-1-3", MenuName = "历史", ParentId = "1-1", MenuDeep = 3, IconClass = "", RoutePath = "/LiShi"});
            }

            if (TempObject.IsAddYinYuFanYi)
            {
                menus.Add(new MenuInfo { MenuId = "1-1-2-2-c", MenuName = "翻译练习", ParentId = "1-1-2-2", MenuDeep = 5, IconClass = "", RoutePath = "/YingYuKouYuLianXi", RouteParentPath = "/YingYu" });
            }

            return menus;
        }

        //private List<RouteViewModel> CreateRouters(List<MenuInfo> menus)
        //{
        //    // 根据菜单信息创建好Vue要使用的路由表
        //    List<RouteViewModel> routers = new List<RouteViewModel>();

        //    RouteViewModel mainRoute = new RouteViewModel()
        //    {
        //        Path = "/",
        //        Component = "Main",
        //        Name = "Main",
        //        Meta = new MyMeta { RequireAuth = true },
        //        Children = new List<RouteViewModel>()
        //    };
        //    routers.Add(mainRoute);

        //    var parentDatas = menus.FindAll(p => !string.IsNullOrEmpty(p.RoutePath) 
        //                                        && string.IsNullOrEmpty(p.RouteParentPath));
        //    if(parentDatas!=null)
        //    {
        //        foreach(var parentData in parentDatas)
        //        {
        //            RouteViewModel router = new RouteViewModel()
        //            {
        //                Path = parentData.RoutePath,
        //                Component = parentData.RouteName,
        //                Name = parentData.RouteName,
        //                Meta = new MyMeta { RequireAuth = parentData.RequireAuth, MenuId = parentData.MenuId },
        //            };
        //            mainRoute.Children.Add(router);

        //            RecursiveAddRouters(menus, router, parentData);
        //        }
        //    }

        //    routers.Add(new RouteViewModel()
        //    {
        //        Path = "/Login",
        //        Component = "Login",
        //        Name = "Login",
        //        Meta = new MyMeta { RequireAuth = false }
        //    });

        //    return routers;
        //}

        ////递归添加路由节点
        //private void RecursiveAddRouters(List<MenuInfo> menus, RouteViewModel parentRouter, MenuInfo parentData)
        //{
        //    var childDatas = menus.FindAll(p => !string.IsNullOrEmpty(p.RoutePath)
        //                                        && p.RouteParentPath == parentData.RoutePath);
        //    if (childDatas == null)
        //    {
        //        return;
        //    }
        //    foreach(var childData in childDatas)
        //    {
        //        RouteViewModel router = new RouteViewModel()
        //        {
        //            Path = childData.RoutePath,
        //            Component = childData.RouteName,
        //            Name = childData.RouteName,
        //            Meta = new MyMeta { RequireAuth = childData.RequireAuth, MenuId = parentData.MenuId },
        //        };
        //        if(parentRouter.Children == null)
        //        {
        //            parentRouter.Children = new List<RouteViewModel>();
        //        }

        //        parentRouter.Children.Add(router);

        //        RecursiveAddRouters(menus, router, childData);
        //    }
        //}

        //private List<MenuViewModel> CreateMenus(List<MenuInfo> menus)
        //{
        //    // 根据菜单信息创建好Vue组件要使用的菜单表
        //    List<MenuViewModel> menuList = new List<MenuViewModel>();

        //    var parentDatas = menus.FindAll(p => string.IsNullOrEmpty(p.ParentId));
        //    if (parentDatas != null)
        //    {
        //        foreach (var parentData in parentDatas)
        //        {
        //            MenuViewModel menuViewModel = new MenuViewModel()
        //            {
        //                MenuId = parentData.MenuId,
        //                MenuName = parentData.MenuName,
        //                ParentId = parentData.ParentId,
        //                IconClass = parentData.IconClass,
        //                RouteName = parentData.RouteName
        //            };
        //            menuList.Add(menuViewModel);

        //            RecursiveAddMenus(menus, menuViewModel, parentData, 1);
        //        }
        //    }
        //    return menuList;
        //}

        ////递归添加菜单
        //private void RecursiveAddMenus(List<MenuInfo> menus, MenuViewModel parentMenuViewModel, MenuInfo parentData, int menuDeep)
        //{
        //    menuDeep++;
        //    var childDatas = menus.FindAll(p => p.ParentId == parentData.MenuId);
        //    if (childDatas == null)
        //    {
        //        return;
        //    }
        //    foreach (var childData in childDatas)
        //    {
        //        MenuViewModel menuViewModel = new MenuViewModel()
        //        {
        //            MenuId = childData.MenuId,
        //            MenuName = childData.MenuName,
        //            ParentId = childData.ParentId,
        //            IconClass = childData.IconClass,
        //            RouteName = childData.RouteName
        //        };
        //        if (parentMenuViewModel.Children == null)
        //        {
        //            parentMenuViewModel.Children = new List<MenuViewModel>();
        //        }

        //        parentMenuViewModel.Children.Add(menuViewModel);

        //        if(menuDeep < LeftMenu_MaxDeep)
        //        {
        //            RecursiveAddMenus(menus, menuViewModel, childData, menuDeep);
        //        }
        //    }
        //}

        //public Tuple<List<MenuViewModel>, List<RouteViewModel>> GetRoutersAndMenus()
        //{
        //    List<MenuInfo> menus = GetTestMenus();
        //    List<RouteViewModel> routeViewModels = CreateRouters(menus);
        //    List<MenuViewModel> menuViewModels = CreateMenus(menus);

        //    return Tuple.Create(menuViewModels, routeViewModels);
        //}

        //在文科下面添加一个科目：历史
        public void AddLiShi()
        {
            TempObject.IsAddLiShi = true;
        }

        //添加：英语翻译
        public void AddYinYuFanYi()
        {
            TempObject.IsAddYinYuFanYi = true;
        }
    }
}
