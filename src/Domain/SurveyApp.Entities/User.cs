﻿using System.Security.Principal;

namespace SurveyApp.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public Role Role { get; set; }
        public ICollection<Survey>? Surveys { get; set; }
    }

    public enum Role
    {
        Admin,
        Member
    }
}