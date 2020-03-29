namespace Trainings.Business.Interfaces
{
    public interface IJwtTokenHelper
    {
        public string GenerateJwtToken(string role, int expiresMinutes);
    }
}
