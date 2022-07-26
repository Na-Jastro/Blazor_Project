﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAV.Models.Dtos
{
    public class ProtectionTypeDto
    {
        public int ProtectionId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ProtectionDescription { get; set; }
        public int UpdatedSystemUserId { get; set; }
        public DateTime LastDateModified { get; set; }
        public bool Deleted { get; set; }
    }
}
