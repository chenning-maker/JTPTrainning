using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Sys
{
    
    public class Sys_Dict_Type: FullAuditedEntity
    {
       public string Code { get; set; }

       public string Value { get; set; }

       public string Name { get; set; }

       public int Sort { get; set; }

     
    }
}
