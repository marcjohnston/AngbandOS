using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollCurseWeapon : ScrollItemClass
    {
        private ScrollCurseWeapon(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Curse Weapon";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Curse Weapon";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.CurseWeapon())
            {
                eventArgs.Identified = true;
            }
        }
    }
}
