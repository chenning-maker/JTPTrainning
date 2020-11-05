using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyProject.Sys.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Sys
{
    //ABP默认启用了IOC，继承这个接口就会自动实现
   public interface ISysMeeting: IApplicationService 
    {
        //插入一条数据：
        Task<bool> InsertMeeting(MeetingDto model);

        //通过ID查询一条数据：
        [HttpGet]
        Task<MeetingDto> GetMeetingById(int id);

        //查询所有
        [HttpGet]
        Task<ListResultDto<MeetingDto>> GetMeetingList(int state);

        //修改数据：
        Task<bool> UpdateMeeting(MeetingDto model);


        //删除数据：
        Task<bool> DelMeeting(int id);

    }
}
