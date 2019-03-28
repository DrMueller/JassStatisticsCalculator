using System.Collections.Generic;

namespace Mmu.Jsc.Domain.Areas.Models.Jass
{
    public class JassSuiteInHand
    {
        public IReadOnlyCollection<JassCard> Cards { get; }
        public JassSuite Suite { get; }

        public JassSuiteInHand(JassSuite suite, IReadOnlyCollection<JassCard> cards)
        {
            Suite = suite;
            Cards = cards;
        }
    }
}