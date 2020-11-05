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
    [AutoMapTo(typeof(User_Type))]
  public  class UsersDto: EntityDto
    {    
        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public int Number { set; get; }

        [Required]
        public string Name { get; set; }

       
        public char Sex { get; set; }

      
        public int Age { get; set; }

        
        public string Address { get; set; }

        [Required]
        public int State { get; set; }



    }
}
