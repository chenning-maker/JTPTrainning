using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Microsoft.EntityFrameworkCore;
using MyProject.Sys.Dto;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace MyProject.Sys
{
  public  class SysUser : ISysUser

    {
        //该对象获取了和数据库交互的所有东西
        IRepository<User_Type, int> _user_repository;

        
        ICacheManager _ICacheManager; //依赖注入缓存

        //构造器依赖注入：
        public SysUser(IRepository<User_Type, int> user_repository, ICacheManager iCacheManager)
        {
            this._user_repository =user_repository;
            _ICacheManager = iCacheManager;  //依赖注入缓存
        }


        //删除一行数据：以isDeleted为准，值为1时该字段被删除！
        //并不是真正的删除，只是将isDeleted置为1了（逻辑删除）
        public async Task<bool> DelUser(int id)
        {
            await _user_repository.DeleteAsync(id);
            return true;
        }

        public async Task<UsersDto> GetUserById(int id)
        {
            return await _ICacheManager.GetCache("SysDict").GetAsync("sysdict" + id, () => Getsysdictbase(id));
        }

        private async Task<UsersDto> Getsysdictbase(int id)
        {

            var sysobj = await _user_repository.FirstOrDefaultAsync(id);
            return sysobj.MapTo<UsersDto>();

        }




        public  async  Task<ListResultDto<UsersDto>> GetUserList(int state)
        {
            return await _ICacheManager.GetCache("SysDict").GetAsync("user1", () => Getlistbase(state));
        }

        //查询所有：
        //Where( w => w.Code == code)：自动过滤掉isdelete=1的数据
        private async Task<ListResultDto<UsersDto>> Getlistbase(int  state)
        {

            var Sys_list = await _user_repository.GetAll().Where(w => w.State == state).ToListAsync();
            return Sys_list.MapTo<ListResultDto<UsersDto>>();
        }




        public  async Task<bool> InsertUser(UsersDto model)
        {
            var sys_model = model.MapTo<User_Type>();
            var back = await _user_repository.InsertAndGetIdAsync(sys_model);
            _ICacheManager.GetCache("SysDict").SetAsync("sysDict" + back, sys_model);

            if (back > 0)
            {
                return true;
            }

            return false;
        }


        public async Task<bool> UpdateUser(UsersDto model)
        {
            
            var sysobj = await _user_repository.FirstOrDefaultAsync(model.Id);
            if (sysobj != null)
            {
                sysobj.Name = model.Name;
                sysobj.Address = model.Address;
                sysobj.Age = model.Age;
                sysobj.Number = model.Number;
                sysobj.Sex = model.Sex;
                sysobj.State = model.State;

            await _user_repository.UpdateAsync(sysobj);
               
            }
                return true;
            
        }




        

        
         }

        
     
    
}
