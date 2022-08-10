using System;
using System.Collections.Generic;

namespace RightMoveADF.Models
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Upassword { get; set; }
        public DateTime? LogintTime { get; set; }
        public bool? IsActive { get; set; }
        public int? LoggedInCount { get; set; }
        public string? Token { get; set; }
    }
}
