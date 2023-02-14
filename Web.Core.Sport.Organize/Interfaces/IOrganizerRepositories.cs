using System.Collections.Generic;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Models;

namespace Web.Core.Sport.Organize.Interfaces
{
    public interface IOrganizerRepositories
    {
        ResponseOrganizerDTO GetOrganizers(int page, int perPage);
        OrganizerDTO GetOrganizer(int id);
        void Create(OrganizerDTO organizerDTO);
        void Update(OrganizerDTO organizerDTO);
        void Delete(int id);
    }
}
