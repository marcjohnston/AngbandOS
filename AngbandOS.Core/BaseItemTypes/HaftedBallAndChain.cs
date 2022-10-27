using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HaftedBallAndChain : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Ball-and-Chain";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "& Ball-and-Chain~";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override bool ShowMods => true;
        public override int? SubCategory => 6;
        public override int Weight => 150;
    }
}
