using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PolearmBroadAxe : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Broad Axe";

        public override int Chance1 => 1;
        public override int Cost => 304;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Broad Axe~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 11;
        public override int Weight => 160;
    }
}
