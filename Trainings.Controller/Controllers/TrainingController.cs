namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Trainings.Business.Interfaces;
    using Trainings.Controller.Constants;

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TrainingController : ControllerBase
    {
        #region Constructor & Properties

        private readonly ITrainingManager _trainingManager;

        public TrainingController(ITrainingManager trainingManager)
        {
            _trainingManager = trainingManager;
        }

        #endregion

        [Authorize]
        [HttpPost("create")]
        public IActionResult Create()
        {
            int userId = int.Parse(GetUserId());
            int? trainingId = _trainingManager.Create(userId);

            if (!trainingId.HasValue)
            {
                return BadRequest(new { message = ErrorsConstants.InsertingError });
            }

            return Ok(trainingId.Value);
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