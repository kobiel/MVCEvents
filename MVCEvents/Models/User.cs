using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCEvents.Models

{
    public class User
    {
        public String Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public String Password { get; set; }
    }

    /*public class UserDBCntext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
    */
    
}