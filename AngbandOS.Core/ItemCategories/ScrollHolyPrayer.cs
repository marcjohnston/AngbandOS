using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollHolyPrayer : ScrollItemClass
    {
        private ScrollHolyPrayer(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Holy Prayer";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 80;
        public override string FriendlyName => "Holy Prayer";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => 35;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.SetTimedBlessing(eventArgs.SaveGame.Player.TimedBlessing + Program.Rng.DieRoll(48) + 24))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
