using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyProject.Sys.Dto;
using System.Threading.Tasks;

namespace MyProject.Sys
{
    //ABP默认启用了IOC，继承这个接口就会自动实现
   public interface ISysUser: IApplicationService 
    {
        //插入一条数据：
        Task<bool> InsertUser(UsersDto model);

        //通过ID查询一条数据：
        [HttpGet]
        Task<UsersDto> GetUserById(int id);

        //查询所有
        [HttpGet]
        Task<ListResultDto<UsersDto>> GetUserList(int state);

        
        //修改数据：
        Task<bool> UpdateUser(UsersDto model);


        //删除数据：
        Task<bool> DelUser(int id);

    }
}
