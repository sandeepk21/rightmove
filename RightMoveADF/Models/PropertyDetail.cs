using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightMoveADF.Models
{
    public partial class PropertyDetail
    {
        [SwaggerSchema(ReadOnly = true)]
        public int? Id { get; set; }
        [Required]
        public string Summary { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public string[]? Features { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? ReceptionRooms { get; set; }
        public string? Parking { get; set; }
        public string? OutsideSpace { get; set; }
        public int? YearBuilt { get; set; }
        public int? InternalArea { get; set; }
        public string? InternalAreaUnit { get; set; }
        public int? LandArea { get; set; }
        public string? LandAreaUnit { get; set; }
        public int? Floors { get; set; }
        public string? EntranceFloor { get; set; }
        public string? Condition { get; set; }
        public string? Accessibility { get; set; }
        public string? Heating { get; set; }
        public string? FurnishedType { get; set; }
        public bool? PetsAllowed { get; set; }
        public bool? SmokersConsidered { get; set; }
        public bool? Deprecated { get; set; }
        public bool? SharersConsidered { get; set; }
        public bool? BurglarAlarm { get; set; }
        public bool? WashingMachine { get; set; }
        public bool? Dishwasher { get; set; }
        public bool? AllBillsInc { get; set; }
        public bool? WaterBillInc { get; set; }
        public bool? GasBillInc { get; set; }
        public bool? ElectricityBillInc { get; set; }
        public bool? OilBillInc { get; set; }
        public bool? CouncilTaxInc { get; set; }
        public bool? CouncilTaxExempt { get; set; }
        public bool? TvLicenceInc { get; set; }
        public bool? SatCableTvBillInc { get; set; }
        public bool? InternetBillInc { get; set; }
        public bool? BusinessForSale { get; set; }
        public bool? CommUseClass { get; set; }
        public bool? CouncilTaxBand { get; set; }
        public int? DomesticRates { get; set; }
        public string? AgentRef { get; set; }
        

        

       
    }
}
