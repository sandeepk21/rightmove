using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Edm;
using Microsoft.OData.ModelBuilder;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RightMoveADF.Models
{
    public partial class PropertyAddress
    {


        [SwaggerSchema(ReadOnly = true)]
        [JsonIgnore]
        public int? Id { get; set; }
        [Required]
        public string HouseNameNumber { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        [Required]
        public string Town { get; set; } = null!;
        [Required]
        public string Postcode1 { get; set; } = null!;
        [Required]
        public string Postcode2 { get; set; } = null!;
        [Required]
        public string DisplayAddress { get; set; } = null!;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? PovLatitude { get; set; }
        public double? PovLongitude { get; set; }
        public double? PovPitch { get; set; }
        public double? PovHeading { get; set; }
        public double? PovZoom { get; set; }
        public string? AgentRef { get; set; }

        



    }
}
