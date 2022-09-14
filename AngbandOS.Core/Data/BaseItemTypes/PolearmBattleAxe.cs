using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PolearmBattleAxe : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Battle Axe";

        public override int Chance1 => 1;
        public override int Cost => 334;
        public override int Dd => 2;
        public override int Ds => 8;
        public override string FriendlyName => "& Battle Axe~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 22;
        public override int Weight => 170;
    }
}
