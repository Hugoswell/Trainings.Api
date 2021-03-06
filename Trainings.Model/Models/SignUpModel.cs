﻿using System;

namespace Trainings.Model.Models
{
    public class SignUpModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public bool HasFilledInformation { get; set; }

        public DateTime? FillInformationDate { get; set; }

        public string RoleCode { get; set; }
    }
}
