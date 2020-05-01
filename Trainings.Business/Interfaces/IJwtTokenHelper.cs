namespace Trainings.Business.Interfaces
{
    public interface IJwtTokenHelper
    {
        string GenerateJwtToken(string userId, string userRole, string userFirstName, bool hasFilledInformation, int expiresMinutes);
    }
}
