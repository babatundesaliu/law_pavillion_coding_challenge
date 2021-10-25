using System;
using System.Collections.Generic;

namespace login_infrastructure.Entities
{   
    public class Account: BaseEntity
    {     
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string PasswordHash { get; set; }       
    }
}