namespace Application.Authorization.RegisterUser
{
    public class RegisterUserRequest
    {
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;
        public string SamePassword { get; init; } = null!;
        public string CaptchaGenerated {  get; init; } = null!;
        public string CaptchaInput { get; init; } = null!;
    }
}
