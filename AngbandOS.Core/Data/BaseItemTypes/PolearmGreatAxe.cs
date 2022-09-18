using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PolearmGreatAxe : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Great Axe";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "& Great Axe~";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override bool ShowMods => true;
        public override int SubCategory => 25;
        public override int Weight => 230;
    }
}
