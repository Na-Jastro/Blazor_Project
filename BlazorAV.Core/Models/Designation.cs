namespace BlazorAV.Core.Models
{
    public class Designation
    {
        public int DesignationId { get; set; }
        public int CompanyId { get; set; }
        public string DesignationDescription { get; set; }
        public int UpdatedSystemUserId { get; set; }
        public DateTime LastDateModified { get; set; }
        public bool Deleted { get; set; }
        public Company Company { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}