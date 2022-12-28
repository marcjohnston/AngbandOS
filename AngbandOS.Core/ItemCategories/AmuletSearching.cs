using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletSearching : AmuletItemClass
    {
        public AmuletSearching(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '"';
        public override string Name => "Searching";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 600;
        public override string FriendlyName => "Searching";
        public override bool HideType => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool Search => true;
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                item.IdentBroken = true;
                item.IdentCursed = true;
                item.TypeSpecificValue = 0 - item.TypeSpecificValue;
            }
        }
    }
}
