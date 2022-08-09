using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionLoseMemories : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Lose Memories";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lose Memories";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 13;
        public override int Weight => 4;
    }
}
