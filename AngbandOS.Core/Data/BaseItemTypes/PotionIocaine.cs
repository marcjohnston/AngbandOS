using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionIocaine : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Iocaine";

        public override int Chance1 => 4;
        public override int Dd => 20;
        public override int Ds => 20;
        public override string FriendlyName => "Iocaine";
        public override int Level => 55;
        public override int Locale1 => 55;
        public override int SubCategory => 23;
        public override int Weight => 4;
    }
}
