using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollRuneofProtection : ScrollItemClass
    {
        private ScrollRuneofProtection(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Rune of Protection";

        public override int[] Chance => new int[] { 2, 4, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Rune of Protection";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 90, 0, 0 };
        public override int? SubCategory => 38;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.ElderSign();
            eventArgs.Identified = true;
        }
    }
}
