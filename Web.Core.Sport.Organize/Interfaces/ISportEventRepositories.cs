﻿using System.Collections.Generic;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Models;

namespace Web.Core.Sport.Organize.Interfaces
{
    public interface ISportEventRepositories
    {
        List<SportEvent> GetSportEvent();
        SportEvent GetSportEvent(int id);
        void Create(SportEventDTO SportEventDTO);
        void Update(SportEventDTO SportEventDTO);
        void Delete(int id);
    }
}