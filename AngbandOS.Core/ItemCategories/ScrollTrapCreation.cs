using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollTrapCreation : ScrollItemClass
    {
        public ScrollTrapCreation(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '?';
        public override string Name => "Trap Creation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Trap Creation";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.TrapCreation())
            {
                eventArgs.Identified = true;
            }
        }
    }
}
