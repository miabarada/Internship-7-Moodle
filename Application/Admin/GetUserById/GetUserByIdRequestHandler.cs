using Application.Common.Model;
using Domain.Common.Validation;
using Domain.DTOs;
using Domain.Persistence.Users;

namespace Application.Admin.GetUserById
{
    public sealed class GetUserByIdRequestHandler : RequestHandler<GetUserByIdRequest, UserDTO>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Result<UserDTO>> HandleRequestAsync(GetUserByIdRequest request, Result<UserDTO> result)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
            {
                result.SetValidationResult(ValidationResult.Error("USER_NOT_FOUND", "Korisnik ne postoji"));
                return result;
            }

            result.SetResult(new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHush = user.PasswordHash,
                Name = user.Name,
                Surname = user.Surname,
                Role = user.Role
            });

            return result;
        }
    }
}
