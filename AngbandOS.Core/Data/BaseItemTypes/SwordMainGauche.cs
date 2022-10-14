using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordMainGauche : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Main Gauche";

        public override int Chance1 => 1;
        public override int Cost => 25;
        public override int Dd => 1;
        public override int Ds => 5;
        public override string FriendlyName => "& Main Gauche~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override bool ShowMods => true;
        public override int? SubCategory => 5;
        public override int Weight => 30;
    }
}
