using Application.Admin.DeleteUser;
using Application.Common.Model;
using Domain.DTOs;
using Domain.Persistence.Users;

namespace Application.Admin.DeletelUser
{
    public sealed class DeleteUserRequestHandler : RequestHandler<DeleteUserRequest, UserDTO>
    {
        IUserRepository _userRepository;

        public DeleteUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Result<UserDTO>> HandleRequestAsync(DeleteUserRequest request, Result<UserDTO> result)
        {
            await _userRepository.DeleteAsync(request.UserId);
            result.SetResult(new UserDTO
            {
                Id = request.UserId
            });
            return result;
        }
    }
}
