namespace Trainings.Model.Models
{
    public class TokenModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string RoleCode { get; set; }

        public string JwtToken { get; set; }

        public bool HasFilledInformation { get; set; }
    }
}
