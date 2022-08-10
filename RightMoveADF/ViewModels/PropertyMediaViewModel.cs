using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RightMoveADF.ViewModels
{
    public class PropertyMediaViewModel
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
