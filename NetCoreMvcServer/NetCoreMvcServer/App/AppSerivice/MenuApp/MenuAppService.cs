using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class MenuAppService : IMenuAppService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public MenuAppService(IMenuRepository menuRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _menuRepository = menuRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public List<MenuDto> GetAllList()
        {
            var menus = _menuRepository.GetAllList().OrderBy(it => it.SerialNumber);
            //使用AutoMapper进行实体转换
            return Mapper.Map<List<MenuDto>>(menus);
        }

        public List<MenuDto> GetMenusByParent(Guid parentId, int startPage, int pageSize, out int rowCount)
        {
            var menus = _menuRepository.LoadPageList(startPage, pageSize, out rowCount, it => it.ParentId == parentId, it => it.SerialNumber);
            return Mapper.Map<List<MenuDto>>(menus);
        }

        public bool InsertOrUpdate(MenuDto dto)
        {
            var menu = _menuRepository.InsertOrUpdate(Mapper.Map<Menu>(dto));
            return menu == null ? false : true;
        }

        public void DeleteBatch(List<Guid> ids)
        {
            _menuRepository.Delete(it => ids.Contains(it.Id));
        }

        public void Delete(Guid id)
        {
            _menuRepository.Delete(id);
        }

        public MenuDto Get(Guid id)
        {
            return Mapper.Map<MenuDto>(_menuRepository.Get(id));
        }
        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<MenuDto> GetMenusByUser(Guid userId)
        {
            List<MenuDto> result = new List<MenuDto>();
            var allMenus = _menuRepository.GetAllList(it=>it.Type == 0).OrderBy(it => it.SerialNumber);

            User curUser = _userRepository.GetWithRoles(userId);
            
            if (curUser.UserRoles == null || curUser.UserRoles.Count == 0)
            {

                result = Mapper.Map<List<MenuDto>>(allMenus);
            }
            else
            {
                UserRole ur = curUser.UserRoles.First<UserRole>();
                Role r = _roleRepository.Get(ur.RoleId);

                string rolename = r.Name;
                if (rolename == "管理员")
                {
                    result = Mapper.Map<List<MenuDto>>(allMenus);
                }
                else if (rolename == "一般用户")
                {
                    List<Menu> menus = new List<Menu>();
                    foreach (Menu m in allMenus)
                    {
                        if (m.Code == "App_SensorData")
                        {
                            menus.Add(m);
                        }
                        else if (m.Code == "App_GroundTruthData")
                        {
                            menus.Add(m);
                        }
                        else if (m.Code == "Map")
                        {
                            menus.Add(m);
                        }
                        else if (m.Code == "Home")
                        {
                            menus.Add(m);
                        }
                    }

                    result = Mapper.Map<List<MenuDto>>(menus);
                }
            }

           
            return result;

            
        }
    }
}
