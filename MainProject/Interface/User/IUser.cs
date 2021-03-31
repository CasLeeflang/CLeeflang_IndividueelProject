using System;

namespace Interface.User
{
    public interface IUser
    {
        DateTime DoB { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}