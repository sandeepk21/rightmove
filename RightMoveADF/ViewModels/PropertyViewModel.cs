using System.ComponentModel.DataAnnotations;

namespace RightMoveADF.ViewModels
{
    public class PropertyViewModel
    {
        [Required]
        public string AgentRef { get; set; } = null!;
        [Required]
        public bool Published { get; set; }
        [Required]
        public string PropertyType { get; set; } = null!;
        [Required]
        public string Status { get; set; } = null!;
        public bool? NewHome { get; set; }
        public bool? StudentProperty { get; set; }
        public bool? HouseFlatShare { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DateAvailable { get; set; }
        public int? ContractMonths { get; set; }
        public int? MinimumTerm { get; set; }
        public string? LetType { get; set; }
        public int? Branch_ID { get; set; }

    }
}
