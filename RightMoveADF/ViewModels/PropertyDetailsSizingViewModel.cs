using Swashbuckle.AspNetCore.Annotations;

namespace RightMoveADF.ViewModels
{
    public class PropertyDetailsSizingViewModel
    {

        [SwaggerSchema(ReadOnly = true)]
        public int? Id { get; set; }
        public int? Minimum { get; set; }
        public int? Maximum { get; set; }
        public string? AreaUnit { get; set; }
        public string? AgentRef { get; set; }

    }
}
