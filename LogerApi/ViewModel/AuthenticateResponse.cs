using LogerApi.Entities;

namespace LogerApi.ViewModel
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }


        public AuthenticateResponse(User user)
        {
            
            Username = user.Username;
            Password = user.PasswordHash;
        }
    }
}