﻿namespace Trainings.Controller.Controllers
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

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserInfoController : ControllerBase
    {
        #region Constructor & Properties

        private readonly IUserInfoManager _userInfoManager;
        private readonly IUserManager _userManager;

        public UserInfoController(
            IUserInfoManager userInfoManager,
            IUserManager userManager)
        {
            _userInfoManager = userInfoManager;
            _userManager = userManager;
        }

        #endregion

        [Authorize]
        [HttpGet("get")]
        public IActionResult Get()
        {
            int userId = int.Parse(GetUserId());
            bool? hasFilledInfo = _userManager.GetHasFilledInfo(userId);

            if (!hasFilledInfo.Value)
            {
                return Ok(
                    new UserInfoViewModel
                    {
                        Age = "",
                        EquipmentId = "",
                        GoalId = "",
                        Height = "",
                        LevelId = "",
                        SexId = "",
                        TrainingDurationId = "",
                        TrainingTypeId = "",
                        Weight = ""
                    }
                );
            }

            UserInfoModel userInfoModel = _userInfoManager.Get(userId);

            if (userInfoModel.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.RetrievingError });
            }

            return Ok(userInfoModel.ToUserInfoViewModel());
        }

        [Authorize]
        [HttpPost("create")]
        public IActionResult Create(UserInfoViewModel userInfoViewModel)
        {
            UserInfoModel userInfoModel = userInfoViewModel.ToUserModel(GetUserId());
            int? userId = _userInfoManager.Create(userInfoModel);
            
            if (!userId.HasValue)
            {
                return BadRequest(new { message = ErrorsConstants.InsertingError });
            }

            return Ok(userId);
        }

        [Authorize]
        [HttpPut("update")]
        public IActionResult Update(UserInfoViewModel userInfoViewModel)
        {
            UserInfoModel userInfoModel = userInfoViewModel.ToUserModel(GetUserId());
            int? userId = _userInfoManager.Update(userInfoModel);

            if (!userId.HasValue)
            {
                return BadRequest(new { message = ErrorsConstants.UpdatingError });
            }

            return Ok(userId);
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