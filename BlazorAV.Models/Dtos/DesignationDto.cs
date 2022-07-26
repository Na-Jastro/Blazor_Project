using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAV.Models.Dtos
{
    public class DesignationDto
    {
        public int DesignationId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string DesignationDescription { get; set; }
        public int UpdatedSystemUserId { get; set; }
        public DateTime LastDateModified { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
    }
}
