using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Jsc.Domain.Areas.Models.Jass
{
    public class JassCard : ValueObject<JassCard>
    {
        private static Lazy<IReadOnlyCollection<JassCard>> _completeSetLazy = new Lazy<IReadOnlyCollection<JassCard>>(
            () =>
            {
                return CardValue.All.SelectMany(
                    cardValue =>
                    {
                        return JassSuite.All.Select(jassSuite => new JassCard(cardValue, jassSuite));
                    }).ToList();
            });
        public static IReadOnlyCollection<JassCard> CompleteSet => _completeSetLazy.Value;
        public CardValue CardValue { get; }
        public JassSuite JassSuite { get; }

        public JassCard(CardValue cardValue, JassSuite jassSuite)
        {
            Guard.ObjectNotNull(() => cardValue);
            Guard.ObjectNotNull(() => jassSuite);

            CardValue = cardValue;
            JassSuite = jassSuite;
        }

        public override string ToString()
        {
            return string.Concat(JassSuite.ToString(), " ", CardValue.ToString());
        }
    }
}