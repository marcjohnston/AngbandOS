using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordRapier : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Rapier";

        public override int Chance1 => 1;
        public override int Cost => 42;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Rapier~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool ShowMods => true;
        public override int SubCategory => 7;
        public override int Weight => 40;
    }
}
