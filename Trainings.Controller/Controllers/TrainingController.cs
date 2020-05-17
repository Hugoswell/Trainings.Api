namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Trainings.Business.Interfaces;
    using Trainings.Common.Helpers;
    using Trainings.Controller.Assemblers;
    using Trainings.Controller.Constants;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

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
        [HttpGet("all")]
        public IActionResult GetTrainingsInfo()
        {
            int userId = int.Parse(GetUserId());
            IEnumerable<TrainingInfoModel> trainingInfoModels = _trainingManager.GetTrainingsInfo(userId);

            if (trainingInfoModels.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.RetrievingError });
            }

            IEnumerable<TrainingInfoViewModel> trainingInfoViewModels = trainingInfoModels
                .Select(tim => tim.ToTrainingInfoViewModel());
            return Ok(trainingInfoViewModels);
        }

        [Authorize]
        [HttpGet("last")]
        public IActionResult GetThreeLastTrainingsInfo()
        {
            int userId = int.Parse(GetUserId());
            IEnumerable<TrainingInfoModel> trainingInfoModels = _trainingManager.GetThreeLastTrainingsInfo(userId);

            if (trainingInfoModels.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.RetrievingError });
            }

            IEnumerable<TrainingInfoViewModel> trainingInfoViewModels = trainingInfoModels
                .Select(tim => tim.ToTrainingInfoViewModel());
            return Ok(trainingInfoViewModels);
        }

        [Authorize]
        [HttpGet("get")]
        public IActionResult GetTraining(int trainingId)
        {
            int userId = int.Parse(GetUserId());
            TrainingModel trainingModel = _trainingManager.GetTraining(userId, trainingId);

            if (trainingModel.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.RetrievingError });
            }

            TrainingViewModel trainingViewModel = trainingModel.ToTrainingViewModel();
            return Ok(trainingViewModel);
        }

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