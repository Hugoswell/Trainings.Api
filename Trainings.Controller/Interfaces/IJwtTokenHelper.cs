namespace Trainings.Controller.Interfaces
{
    public interface IJwtTokenHelper
    {
        public string GenerateJwtToken(string role, int expiresMinutes);
    }
}
