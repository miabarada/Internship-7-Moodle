using Application.Common.Model;
using Domain.Common.Validation;
using Domain.DTOs;
using Domain.Persistence.Users;

namespace Application.Authorization.LoginUser
{
    public sealed class LoginUserRequestHandler : RequestHandler<LoginUserRequest, UserDTO>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Result<UserDTO>> HandleRequestAsync(LoginUserRequest request, Result<UserDTO> result)
        {
            var user = await _userRepository.GetByEmail(request.Email);

            if(user == null || user.PasswordHash != request.Password)
            {
                result.SetValidationResult(ValidationResult.Error("LOGIN_FAILED", "Nespravan email ili lozinka"));
                return result;
            }

            result.SetResult(new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role
            });

            return result;
        }
    }
}
