using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordTwoHandedSword : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Two-Handed Sword";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 775;
        public override int Dd => 3;
        public override int Ds => 6;
        public override string FriendlyName => "& Two-Handed Sword~";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int Locale2 => 40;
        public override bool ShowMods => true;
        public override int SubCategory => 25;
        public override int Weight => 200;
    }
}
