namespace CLeeflang_IndividueelProject.Models
{
    public interface IBusinessUserView
    {
        string BusinessName { get; set; }
        string Description { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}