namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Trainings.Controller.ViewModels;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult Create(UserViewModel userViewModel)
        {
            return Ok(userViewModel);
        }
    }
}