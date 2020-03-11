namespace Trainings.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public byte RoleId { get; set; }

        public string Email { get; set; }

        public string JwtToken { get; set; }
    }
}
