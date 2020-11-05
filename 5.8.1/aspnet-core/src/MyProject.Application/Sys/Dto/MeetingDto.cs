using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using MyProject.Sys;

namespace MyProject.Sys.Dto
{
    [AutoMapTo(typeof(Meeting_Type))]
  public  class MeetingDto: EntityDto
    {
        //会议：编号，会议名称，开始时间，结束时间、开会地址，描述，创建人
        [Required]
        public int Number { set; get; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string MeetingName { set; get; }

        [Required]
        public DateTime StartTime { set; get; }

        [Required]
        public DateTime EndTime { set; get; }

        [Required]
        public string Address { set; get; }

        [Required]
        public string Describe { set; get; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string CreateUserName { set; get; }

        [Required]
        public int State { get; set; }


    }
}
