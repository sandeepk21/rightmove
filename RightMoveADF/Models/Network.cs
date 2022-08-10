using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightMoveADF.Models
{
    public partial class Network
    {
        [Key]
        [Required]
        public long NetworkId { get; set; }
      

        
    }
}
