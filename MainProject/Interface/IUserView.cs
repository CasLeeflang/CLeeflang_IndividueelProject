namespace CLeeflang_IndividueelProject.Models
{
    public interface IUserView
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}