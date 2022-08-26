using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class Bolt : BoltItemCategory
    {
        public override char Character => '{';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Bolt:Bolt";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 5;
        public override string FriendlyName => "& Bolt~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int Locale2 => 25;
        public override bool ShowMods => true;
        public override int SubCategory => 1;
        public override int Weight => 3;
    }
}
