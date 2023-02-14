using System.Collections.Generic;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Models;

namespace Web.Core.Sport.Organize.Interfaces
{
    public interface IOrganizerRepositories
    {
        List<Organizer> GetOrganizer();
        Organizer GetOrganizer(int id);
        void Create(OrganizerDTO organizerDTO);
        void Update(OrganizerDTO organizerDTO);
        void Delete(int id);
    }
}
