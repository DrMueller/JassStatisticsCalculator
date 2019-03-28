using System;
using System.Collections.Generic;

namespace Mmu.Jsc.Domain.Areas.Models.Jass
{
    public class CardValue
    {
        private static Lazy<IReadOnlyCollection<CardValue>> _allLazy = new Lazy<IReadOnlyCollection<CardValue>>(
            () => new List<CardValue>
            {
                new CardValue(CardValueType.Sechs),
                new CardValue(CardValueType.Sieben),
                new CardValue(CardValueType.Acht),
                new CardValue(CardValueType.Neun),
                new CardValue(CardValueType.Zehn),
                new CardValue(CardValueType.Bube),
                new CardValue(CardValueType.Dame),
                new CardValue(CardValueType.König),
                new CardValue(CardValueType.Ass)
            });

        public static IReadOnlyCollection<CardValue> All => _allLazy.Value;
        public CardValueType CardValueType { get; }

        public CardValue(CardValueType cardValueType)
        {
            CardValueType = cardValueType;
        }

        public override string ToString()
        {
            return CardValueType.ToString();
        }
    }
}