using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SorceryBookUnaussprechlichenKulten : SorceryBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Blue;
        public override string Name => "SorceryBook:[Unaussprechlichen Kulten]";

        public override int Chance1 => 1;
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Unaussprechlichen Kulten]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int SubCategory => 2;
        public override int Weight => 30;
    }
}
