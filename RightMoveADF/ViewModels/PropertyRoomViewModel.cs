using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RightMoveADF.ViewModels
{
    public class PropertyRoomViewModel
    {
        [SwaggerSchema(ReadOnly = true)]
        public int? Id { get; set; }
        [Required]
        public string RoomName { get; set; } = null!;
        public string? RoomDescription { get; set; }
        public double? RoomLength { get; set; }
        public double? RoomWidth { get; set; }
        public string? RoomDimensionUnit { get; set; }
        public string? RoomDimensionsText { get; set; }
        public string? RoomPhotoUrl { get; set; }
        public string? AgentRef { get; set; }

    }
}
