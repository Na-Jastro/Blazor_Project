using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAV.Core.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public int ParentComapnyId { get; set; }
        public string CompanyName { get; set; }
        public bool PortalAccess { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedSystemUserId { get; set; }
        public DateTime LastDateModified { get; set; }
        public bool Deleted { get; set; }
        [NotMapped]
        public ICollection<Client> Clients { get; set; }
        [NotMapped]
        public ICollection<Designation> Designations { get; set; }
        [NotMapped]
        public ICollection<ProtectionType> ProtectionTypes { get; set; }
    }
}