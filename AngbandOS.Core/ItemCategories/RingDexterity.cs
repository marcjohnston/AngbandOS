using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingDexterity : RingItemClass
    {
        public RingDexterity(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '=';
        public override string Name => "Dexterity";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override bool Dex => true;
        public override string FriendlyName => "Dexterity";
        public override bool HideType => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 26;
        public override int Weight => 2;
    }
}
