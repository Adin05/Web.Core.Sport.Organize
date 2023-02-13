using Web.Core.Sport.Organize.DTOs;

namespace Web.Core.Sport.Organize.Interfaces
{
    public interface IAccountRepositories
    {
        UserDTO Login(string username, string password);
        UserDTO Register(RegisterDTO registerDTO);
    }
}
