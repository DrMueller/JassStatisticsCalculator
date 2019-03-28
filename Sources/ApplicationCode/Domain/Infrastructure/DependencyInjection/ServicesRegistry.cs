using StructureMap;

namespace Mmu.Jsc.Services.Infrastructure.DependencyInjection
{
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ServicesRegistry>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}