namespace RightMoveADF.ViewModels
{
    public class LoginViewModel
    {
      
        public int Id { get; set; }
        public string? UserId { get; set; }

        public string? Upassword { get; set; }

        public DateTime? LogintTime { get; set; }

        public bool? IsActive { get; set; }

        public bool? LoggedInCount { get; set; }
        public string? Token { get; set; }
    }
}
