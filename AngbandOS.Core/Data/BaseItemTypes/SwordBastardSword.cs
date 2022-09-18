using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordBastardSword : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Bastard Sword";

        public override int Chance1 => 1;
        public override int Cost => 350;
        public override int Dd => 3;
        public override int Ds => 4;
        public override string FriendlyName => "& Bastard Sword~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 21;
        public override int Weight => 140;
    }
}
