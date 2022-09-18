using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class TarotBookCardMastery : TarotBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "TarotBook:[Card Mastery]";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Card Mastery]";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 1;
        public override int Weight => 30;
    }
}
