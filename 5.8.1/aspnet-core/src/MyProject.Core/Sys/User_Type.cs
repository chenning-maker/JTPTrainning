using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Sys
{
    
    public class User_Type: FullAuditedEntity
    {
        
        public int Number { set; get; }

        public string Name { get; set; }


        public char Sex { get; set; }


        public int Age { get; set; }


        public string Address { get; set; }

        public int State { get; set; }



    }
}
