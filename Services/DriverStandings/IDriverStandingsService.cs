using HYasinDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYasinDemoApp.Services.DriverStandings
{
    public interface IDriverStandingsService
    {
        Task<List<DriverStanding>> GetDriverStandingsAsync();
    }
}
