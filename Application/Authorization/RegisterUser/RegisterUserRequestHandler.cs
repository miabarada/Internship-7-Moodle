using Application.Common.Model;
using Domain.Common.Validation;
using Domain.DTOs;
using Domain.Entities;
using Domain.Persistence.Users;
using System.Text.RegularExpressions;

namespace Application.Authorization.RegisterUser
{
    public sealed class RegisterUserRequestHandler : RequestHandler<RegisterUserRequest, RegisterUserDTO>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Result<RegisterUserDTO>> HandleRequestAsync(RegisterUserRequest request, Result<RegisterUserDTO> result)
        {
            if(!IsValidEmail(request.Email))
            {
                result.SetValidationResult(ValidationResult.Error("INVALID_EMAIL", "Formst emaila je nepravilan"));
                return result;
            }

            if(await _userRepository.Exists(request.Email))
            {
                result.SetValidationResult(ValidationResult.Error("EMAIL_EXISTS", "Email već postoji"));
                return result;
            }

            if(request.Password != request.SamePassword)
            {
                result.SetValidationResult(ValidationResult.Error("PASSWORD_NOT_THE_SAME", "Lozinke se ne poklapaju"));
                return result;
            }

            if(!string.Equals(request.CaptchaGenerated, request.CaptchaInput))
            {
                result.SetValidationResult(ValidationResult.Error("CAPTCHA_INVALID", "Captcha je neispravna"));
                return result;
            }

            var user = new User
            {
                Email = request.Email,
                PasswordHash = request.Password,
                Role = Domain.Enums.Role.Student
            };

            _userRepository.Add(user);
            result.SetResult(new RegisterUserDTO
            {
                UserId = user.Id,
            });
            return result;
        }

        private static bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[^@]+@.{2,}\..{3,}$");
            return regex.IsMatch(email);
        }
    }
}
