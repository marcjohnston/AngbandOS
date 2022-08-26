using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SwordExecutionersSword : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.Red;
        public override string Name => "Sword:Executioner's Sword";

        public override int Chance1 => 1;
        public override int Cost => 850;
        public override int Dd => 4;
        public override int Ds => 5;
        public override string FriendlyName => "& Executioner's Sword~";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override bool ShowMods => true;
        public override int SubCategory => 28;
        public override int Weight => 260;
    }
}
