namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Trainings.Business.Interfaces;

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
            return Ok();
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