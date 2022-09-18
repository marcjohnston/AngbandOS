using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PolearmSpear : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Spear";

        public override int Chance1 => 1;
        public override int Cost => 36;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Spear~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool ShowMods => true;
        public override int SubCategory => 2;
        public override int Weight => 50;
    }
}
