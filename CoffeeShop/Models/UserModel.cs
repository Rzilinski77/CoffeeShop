using System;

namespace CoffeeShop.Models
{
    public partial class UserModel
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
