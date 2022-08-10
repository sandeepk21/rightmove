namespace RightMoveADF.ViewModels
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PostCode { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDts { get; set; }
        public bool? IsLock { get; set; }
        public string? ShowDate { get; set; }
    }
}
