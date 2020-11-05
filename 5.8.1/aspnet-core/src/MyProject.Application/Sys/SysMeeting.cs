using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Microsoft.EntityFrameworkCore;
using MyProject.Sys.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Sys
{
    public  class SysMeeting : ISysMeeting
    {

        
        IRepository<Meeting_Type, int> _meeting_repository;
        ICacheManager _ICacheManager; 


        //构造器依赖注入：
        public SysMeeting(IRepository<Meeting_Type,int> meeting_repository, ICacheManager iCacheManager)
        {
            this._meeting_repository = meeting_repository;
            _ICacheManager = iCacheManager;  
        }


        public async Task<bool> DelMeeting(int id)
        {
            await _meeting_repository.DeleteAsync(id);
            return true;
        }

        public async Task<MeetingDto> GetMeetingById(int id)
        {
            return await _ICacheManager.GetCache("SysDict").GetAsync("sysdict" + id, () => Getsysdictbase(id));
        }

        private async Task<MeetingDto> Getsysdictbase(int id)
        {

            var sysobj = await _meeting_repository.FirstOrDefaultAsync(id);
            return sysobj.MapTo<MeetingDto>();

        }

        public async Task<ListResultDto<MeetingDto>> GetMeetingList(int state)
        {
            return await _ICacheManager.GetCache("SysDict").GetAsync("user1", () => Getlistbase(state));
        }

        //查询所有：
        //Where( w => w.Code == code)：自动过滤掉isdelete=1的数据
        private async Task<ListResultDto<MeetingDto>> Getlistbase(int state)
        {

            var Sys_list = await _meeting_repository.GetAll().Where(w => w.State == state).ToListAsync();
            return Sys_list.MapTo<ListResultDto<MeetingDto>>();
        }

        public async Task<bool> InsertMeeting(MeetingDto model)
        {
            var sys_model = model.MapTo<Meeting_Type>();
            var back = await _meeting_repository.InsertAndGetIdAsync(sys_model);
            _ICacheManager.GetCache("SysDict").SetAsync("sysDict" + back, sys_model);

            if (back > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateMeeting(MeetingDto model)
        {
            var sysobj = await _meeting_repository.FirstOrDefaultAsync(model.Id);
            if (sysobj != null)
            {
                sysobj.Number = model.Number;
                sysobj.MeetingName = model.MeetingName;
                sysobj.StartTime = model.StartTime;
                sysobj.EndTime = model.EndTime;
                sysobj.Address = model.Address;
                sysobj.Describe = model.Describe;
                sysobj.CreateUserName = model.CreateUserName;
                sysobj.State = model.State;

                await _meeting_repository.UpdateAsync(sysobj);

            }
            return true;

        }
    }
}
