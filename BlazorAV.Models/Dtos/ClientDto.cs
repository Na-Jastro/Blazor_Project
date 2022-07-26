using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAV.Models.Dtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int DesignationId { get; set; }
        public string DesignationDescription { get; set; }
        public int ProtectionTypeId { get; set; }
        public string ProtectionDescription { get; set; }
        public bool PortalAccess { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedSystemUserId { get; set; }
        public DateTime LastDateModified { get; set; }
        public bool Deleted { get; set; }

    }
}
