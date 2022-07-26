using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAV.Models.Dtos
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Please enter Parent Company Id.")]
        public int ParentComapnyId { get; set; }
        [Required(ErrorMessage = "Please enter Parent Company Name.")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter Portal Access.")]
        public bool PortalAccess { get; set; }
        [Required(ErrorMessage = "Please select Active.")]
        public bool IsActive { get; set; }
        public int UpdatedSystemUserId { get; set; }
        public DateTime LastDateModified { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please select to delete.")]
        public bool Deleted { get; set; }
    }
}
