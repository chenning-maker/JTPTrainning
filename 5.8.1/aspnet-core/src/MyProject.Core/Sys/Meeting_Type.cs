using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Sys
{
    
    public class Meeting_Type: FullAuditedEntity
    {

        public int Number { set; get; }

        public string MeetingName { set; get; }
     
        public DateTime StartTime { set; get; }     
        public DateTime EndTime { set; get; }
      
        public string Address { set; get; }       
        public string Describe { set; get; }    
        public string CreateUserName { set; get; }

        public int State { get; set; }
    }
}
