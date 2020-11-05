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
    [AutoMapTo(typeof(Sys_Dict_Type))]
  public  class SysdictDto: EntityDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        
        [Required]
        public string Value { get; set; }

        
        public int Sort { get; set; }

    }
}
