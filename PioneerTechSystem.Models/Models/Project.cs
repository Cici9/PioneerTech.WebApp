using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerTechSystem.Models
{
    public class Project
    {
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string ProjectLocation { get; set; }
        public string ProjectRoles { get; set; }
    }
}
