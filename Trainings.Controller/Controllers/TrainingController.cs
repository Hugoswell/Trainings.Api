namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Trainings.Business.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        #region Constructor & Properties

        private readonly ITrainingManager _trainingManager;

        public TrainingController(ITrainingManager trainingManager)
        {
            _trainingManager = trainingManager;
        }

        #endregion
    }
}