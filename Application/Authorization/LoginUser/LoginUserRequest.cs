namespace Application.Authorization.LoginUser
{
    public class LoginUserRequest
    {
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;

        public LoginUserRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
