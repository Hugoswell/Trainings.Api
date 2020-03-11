﻿namespace Trainings.Business.Models
{
    public class UserManagerModel
    {
        public int Id { get; set; }

        public byte RoleId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string RoleName { get; set; }
    }
}
