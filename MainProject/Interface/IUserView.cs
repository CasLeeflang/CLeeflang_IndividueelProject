using System;

namespace Interface
{
    public interface IUserView
    {
        DateTime DoB { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}