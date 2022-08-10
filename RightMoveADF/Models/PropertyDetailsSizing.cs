using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightMoveADF.Models
{
    public partial class PropertyDetailsSizing
    {
        [SwaggerSchema(ReadOnly = true)]
        public int? Id { get; set; }
        public int? Minimum { get; set; }
        public int? Maximum { get; set; }
        public string? AreaUnit { get; set; }
        public string? AgentRef { get; set; }
        

        
    }
}
