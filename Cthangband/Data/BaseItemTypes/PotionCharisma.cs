using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionCharisma : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Charisma";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Charisma";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int Locale2 => 25;
        public override int SubCategory => 53;
        public override int Weight => 4;
    }
}
