using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ShotIronShot : ShotItemCategory
    {
        public override char Character => '{';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Iron Shot";

        public override int Chance1 => 1;
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Iron Shot~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override bool ShowMods => true;
        public override int? SubCategory => 1;
        public override int Weight => 5;
    }
}
