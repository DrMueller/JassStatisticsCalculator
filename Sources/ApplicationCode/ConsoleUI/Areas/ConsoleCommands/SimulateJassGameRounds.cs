using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Jsc.ConsoleUI.Areas.Models;
using Mmu.Jsc.ConsoleUI.Areas.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace Mmu.Jsc.ConsoleUI.Areas.ConsoleCommands
{
    public class SimulateJassGameRounds : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ISimulationService _simulationService;
        public string Description { get; } = "Simulate Jass rounds";
        public ConsoleKey Key { get; } = ConsoleKey.D1;

        public SimulateJassGameRounds(ISimulationService simulationService, IConsoleWriter consoleWriter)
        {
            _simulationService = simulationService;
            _consoleWriter = consoleWriter;
        }

        public async Task ExecuteAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            const long AmountOfRuns = 10000000;

            var simulationTasks = new List<Task<SimulationRunResult>>();

            for (var i = 0; i < AmountOfRuns; i++)
            {
                simulationTasks.Add(_simulationService.RunSimulationAsync());
            }

            var simulationResults = await Task.WhenAll(simulationTasks);
            var foundSixThree = simulationResults.Sum(f => f.AmountSixThreeCombinations);
            var foundSevenTwo = simulationResults.Sum(f => f.AmountSevenTwoCombinations);
            var totalRuns = simulationResults.Length;

            var result = new SimulationResult(totalRuns, foundSixThree, foundSevenTwo);

            _consoleWriter.WriteLine($"Calculation took {stopwatch.Elapsed.Minutes} Minutes.", ConsoleColor.Black, ConsoleColor.Green);
            _consoleWriter.WriteLine(
                $"Total Runs: {result.TotalRuns}. Seven Twos: {result.SevenTwoCombinationAmount}. Six Threes: {result.SixThreeCombinationAmount}.",
                ConsoleColor.Black,
                ConsoleColor.DarkYellow);

            _consoleWriter.WriteLine(result.PercentDescriptionOfSevenTwo, ConsoleColor.Black, ConsoleColor.Yellow);
            _consoleWriter.WriteLine(result.PercentDescriptionOfSixThree, ConsoleColor.Black, ConsoleColor.Yellow);
        }
    }
}