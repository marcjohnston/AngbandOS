using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialRemoveCurse : ScrollItemClass
    {
        public ScrollSpecialRemoveCurse(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '?';
        public override string Name => "*Remove Curse*";

        public override int[] Chance => new int[] { 2, 2, 2, 1 };
        public override int Cost => 8000;
        public override string FriendlyName => "*Remove Curse*";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 75, 85, 95 };
        public override int? SubCategory => 15;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.RemoveAllCurse();
            eventArgs.Identified = true;
        }
    }
}
