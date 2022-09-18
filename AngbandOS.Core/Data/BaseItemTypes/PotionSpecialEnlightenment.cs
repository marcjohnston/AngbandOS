using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSpecialEnlightenment : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:*Enlightenment*";

        public override int Chance1 => 4;
        public override int Cost => 80000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "*Enlightenment*";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int SubCategory => 57;
        public override int Weight => 4;
    }
}
