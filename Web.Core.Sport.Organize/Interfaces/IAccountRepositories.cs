using System.Threading.Tasks;
using Web.Core.Sport.Organize.DTOs;

namespace Web.Core.Sport.Organize.Interfaces
{
    public interface IAccountRepositories
    {
        Task<UserDTO> Login(string username, string password);
        Task<RegisterResponseDTO> Register(RegisterDTO registerDTO);
    }
}
