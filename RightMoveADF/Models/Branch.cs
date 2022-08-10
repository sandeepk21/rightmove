using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightMoveADF.Models
{
    public partial class Branch
    {
        [Key]
        [Required]
        public int BranchId { get; set; }
        [Required]
        public int Channel { get; set; }
        public bool? Overseas { get; set; }
        public string NetworkId { get; set; }

        
    }
}
