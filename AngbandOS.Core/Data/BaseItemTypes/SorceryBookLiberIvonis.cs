using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SorceryBookLiberIvonis : SorceryBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Blue;
        public override string Name => "SorceryBook:[Liber Ivonis]";

        public override int Chance1 => 3;
        public override int Cost => 100000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Liber Ivonis]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 90;
        public override int Locale1 => 90;
        public override int SubCategory => 3;
        public override int Weight => 30;
    }
}
