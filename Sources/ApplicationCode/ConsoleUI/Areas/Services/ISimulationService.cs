using System.Threading.Tasks;
using Mmu.Jsc.ConsoleUI.Areas.Models;

namespace Mmu.Jsc.ConsoleUI.Areas.Services
{
    public interface ISimulationService
    {
        Task<SimulationRunResult> RunSimulationAsync();
    }
}