using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionAugmentation : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Augmentation";

        public override int Chance1 => 16;
        public override int Cost => 60000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Augmentation";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int? SubCategory => 55;
        public override int Weight => 4;
    }
}
