using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class TarotBookConjuringsTricks : TarotBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "TarotBook:[Conjurings  Tricks]";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Conjurings & Tricks]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Weight => 30;
    }
}
