using System.Linq;
using System.Threading.Tasks;
using Mmu.Jsc.ConsoleUI.Areas.Models;
using Mmu.Jsc.Domain.Areas.Models.Jass;
using Mmu.Jsc.Domain.Areas.Services;

namespace Mmu.Jsc.ConsoleUI.Areas.Services.Implementation
{
    public class SimulationService : ISimulationService
    {
        private readonly IJassGameRoundFactory _jassGameRoundFactory;

        public SimulationService(IJassGameRoundFactory jassGameRoundFactory)
        {
            _jassGameRoundFactory = jassGameRoundFactory;
        }

        public Task<SimulationRunResult> RunSimulationAsync()
        {
            var gameRound = _jassGameRoundFactory.CreateOneRound();
            var combosWith6 = CheckForCombinations(gameRound, 6);
            var combosWith7 = CheckForCombinations(gameRound, 7);

            return Task.FromResult(new SimulationRunResult(combosWith6, combosWith7));
        }

        private static int CheckForCombinations(JassGameRound gameRound, int amountOfSameSuite)
        {
            var remainingCardAmountForEnemy = 9 - amountOfSameSuite;
            var playerWithAmount = gameRound.GetPlayersWithSuiteCombinations(amountOfSameSuite);

            var playersWithCombo = 0;
            foreach (var playerWithSuites in playerWithAmount)
            {
                var enemyHas3 = gameRound.JassPlayers
                    .Any(
                        f => !f.IsPartnerOf(playerWithSuites.Player)
                            && f.JassHand.SuitesInHand.Any(c => c.Suite == playerWithSuites.SuiteInHand.Suite && c.Cards.Count == remainingCardAmountForEnemy));

                if (enemyHas3)
                {
                    playersWithCombo++;
                }
            }

            return playersWithCombo;
        }
    }
}