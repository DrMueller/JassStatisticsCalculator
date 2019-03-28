using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using StructureMap;

namespace Mmu.Jsc.ConsoleUI.Infrastructure.DependencyInjection
{
    public class ConsoleUiRegistry : Registry
    {
        public ConsoleUiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ConsoleUiRegistry>();
                    scanner.AddAllTypesOf<IConsoleCommand>();

                    scanner.WithDefaultConventions();
                });
        }
    }
}