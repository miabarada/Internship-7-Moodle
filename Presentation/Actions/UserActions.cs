using Application.Admin.DeletelUser;
using Application.Admin.GetUserById;
using Application.Authorization.LoginUser;
using Application.Authorization.RegisterUser;
using Application.Common;
using Application.PrivateMessages.GetChat;
using Application.PrivateMessages.GetUserChats;

namespace Presentation.Actions
{
    public class UserActions 
    { 
        private readonly LoginUserRequestHandler _loginUserRequestHandler; 
        private readonly RegisterUserRequestHandler _registerUserRequestHandler; 
        private readonly GetUserByIdRequestHandler _getUserByIdRequestHandler; 
        private readonly DeleteUserRequestHandler _deleteUserRequestHandler; 
        private readonly GetChatRequestHandler _getChatRequestHandler; 
        private readonly GetUserChatsRequestHandler _getUserChatsRequestHandler; 
        
        public UserActions(LoginUserRequestHandler loginUserRequestHandler, RegisterUserRequestHandler registerUserRequestHandler, GetUserByIdRequestHandler getUserByIdRequestHandler, DeleteUserRequestHandler deleteUserRequestHandler, GetChatRequestHandler getChatRequestHandler, GetUserChatsRequestHandler getUserChatsRequestHandler) 
        { 
            _loginUserRequestHandler = loginUserRequestHandler; 
            _registerUserRequestHandler = registerUserRequestHandler; 
            _getUserByIdRequestHandler = getUserByIdRequestHandler; 
            _deleteUserRequestHandler = deleteUserRequestHandler; 
            _getChatRequestHandler = getChatRequestHandler; 
            _getUserChatsRequestHandler = getUserChatsRequestHandler; 
        }

        public async Task<UserResponse?> LoginUserAsync(string email, string password)
        {
            var result = await _loginUserRequestHandler.ProcessAuthorizedRequestAsync(new LoginUserRequest(email, password));

            if (result.Value == null)
                return null;

            return new UserResponse
            {
                Id = result.Value.Id,
                Email = result.Value.Email,
                PasswordHash = result.Value.PasswordHush,
                Name = result.Value.Name,
                Surname = result.Value.Surname,
                Role = result.Value.Role
            };

        }
    }
}
