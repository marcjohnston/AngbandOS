using AngbandOS.Core.Interface;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ChestLargeWooden : ChestItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Chest:Large wooden chest";

        public override int Chance1 => 1;
        public override int Cost => 60;
        public override int Dd => 2;
        public override int Ds => 5;
        public override string FriendlyName => "& Large wooden chest~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int? SubCategory => 5;
        public override int Weight => 500;
    }
}
