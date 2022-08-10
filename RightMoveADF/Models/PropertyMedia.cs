using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightMoveADF.Models
{
    public partial class PropertyMedia
    {
        [SwaggerSchema(ReadOnly = true)]
        public int? Id { get; set; }
        [Required]
        public string MediaType { get; set; } = null!;
        [Required]
        public string MediaUrl { get; set; } = null!;
        public string? Caption { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? MediaUpdateDate { get; set; }
        public string? AgentRef { get; set; }
        
        

        
    }
}
