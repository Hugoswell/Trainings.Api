namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Trainings.Business.Interfaces;
    using Trainings.Controller.Constants;

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region Constructor & Properties

        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        #endregion

        [Authorize]
        [HttpGet("gethasfilledinfo")]
        public IActionResult GetHasFilledInfo()
        {
            int userId = int.Parse(GetUserId());
            bool? hasFilledInfo = _userManager.GetHasFilledInfo(userId);

            if (!hasFilledInfo.HasValue)
            {
                return BadRequest(new { message = ErrorsConstants.RetrievingError });
            }

            return Ok(hasFilledInfo);
        }

        #region Private

        private string GetUserId()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claims = identity.Claims.ToList();
            return claims[0].Value;
        }

        #endregion
    }
}