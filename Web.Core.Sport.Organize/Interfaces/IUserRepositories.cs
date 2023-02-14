using System.Collections.Generic;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Models;

namespace Web.Core.Sport.Organize.Interfaces
{
    public interface IUserRepositories
    {
        UserDTO GetUser(int id, string accessToken);
        void Update(UserDTO userDTO);
        void ChangePassword(ChangePasswordDTO userDTO);
        void Delete(int id);
    }
}
