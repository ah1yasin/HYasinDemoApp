using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYasinDemoApp.Models;

namespace HYasinDemoApp.Services.Circuits
{
    public interface ICircuitsService
    {
        Task<List<Circuit>> GetCircuitsAsync();
    }
}
