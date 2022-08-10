using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightMoveADF.ViewModels
{
    public partial class NetworkViewModel
    {
        [Key]
        [Required]
        public long NetworkId { get; set; }



    }
}
