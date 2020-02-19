using System;
using Trainings.Business.Interface;
using Trainings.Repository.Interface;

namespace Trainings.Business
{
    public class RegisterBusiness : IRegisterBusiness
    {
        #region Constructor & Properties

        private readonly IRegisterRepository _registerRepository;

        public RegisterBusiness(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository ?? throw new ArgumentNullException(nameof(registerRepository));
        }

        #endregion

        
    }
}
