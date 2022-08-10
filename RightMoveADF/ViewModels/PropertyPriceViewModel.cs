using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RightMoveADF.ViewModels
{
    public class PropertyPriceViewModel
    {
        [SwaggerSchema(ReadOnly = true)]
        public int? Id { get; set; }
        [Required]
        public int Price { get; set; }
        public string? PriceQualifier { get; set; }
        public int? Deposit { get; set; }
        public string? AdministrationFee { get; set; }
        public string? RentFrequency { get; set; }
        public string? TenureType { get; set; }
        public bool? Auction { get; set; }
        public int? TenureUnexpiredYears { get; set; }
        public int? PricePerUnitArea { get; set; }
        public int? PricePerUnitPerAnnum { get; set; }
        public bool? SharedOwnership { get; set; }
        public double? SharedOwnershipPercentage { get; set; }
        public double? SharedOwnershipRent { get; set; }
        public int? SharedOwnershipRentFrequency { get; set; }
        public int? AnnualGroundRent { get; set; }
        public int? GroundRentReviewPeriodYears { get; set; }
        public double? GroundRentPercentageIncrease { get; set; }
        public int? AnnualServiceCharge { get; set; }
        public string? AgentRef { get; set; }
    }
}
