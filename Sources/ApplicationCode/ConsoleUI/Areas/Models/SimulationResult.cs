using System;

namespace Mmu.Jsc.ConsoleUI.Areas.Models
{
    public class SimulationResult
    {
        public string PercentDescriptionOfSevenTwo
        {
            get
            {
                var percentage = (double)SevenTwoCombinationAmount / TotalRuns * 100;
                percentage = Math.Round(percentage, 2);
                return $"Percent for Seven/Two: {percentage} %";
            }
        }

        public string PercentDescriptionOfSixThree
        {
            get
            {
                var percentage = (double)SixThreeCombinationAmount / TotalRuns * 100;
                percentage = Math.Round(percentage, 2);
                return $"Percent for Six/Three: {percentage} %";
            }
        }

        public long SevenTwoCombinationAmount { get; }
        public long SixThreeCombinationAmount { get; }
        public long TotalRuns { get; }

        public SimulationResult(long totalRuns, long sixThreeCombinationAmount, long sevenTwoCombinationAmount)
        {
            TotalRuns = totalRuns;
            SixThreeCombinationAmount = sixThreeCombinationAmount;
            SevenTwoCombinationAmount = sevenTwoCombinationAmount;
        }
    }
}