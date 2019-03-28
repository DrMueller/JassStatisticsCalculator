namespace Mmu.Jsc.ConsoleUI.Areas.Models
{
    public class SimulationRunResult
    {
        public int AmountSevenTwoCombinations { get; }
        public int AmountSixThreeCombinations { get; }

        public SimulationRunResult(int amountSixThreeCombinations, int amountSevenTwoCombinations)
        {
            AmountSixThreeCombinations = amountSixThreeCombinations;
            AmountSevenTwoCombinations = amountSevenTwoCombinations;
        }
    }
}