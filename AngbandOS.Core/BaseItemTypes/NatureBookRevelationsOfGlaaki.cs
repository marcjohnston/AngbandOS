using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class NatureBookRevelationsOfGlaaki : NatureBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Green;
        public override string Name => "[Revelations of Glaaki]";

        public override int Chance1 => 1;
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Revelations of Glaaki]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int? SubCategory => 2;
        public override int Weight => 30;
    }
}
