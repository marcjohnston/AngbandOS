using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollHolyChant : ScrollItemClass
    {
        public ScrollHolyChant(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '?';
        public override string Name => "Holy Chant";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 40;
        public override string FriendlyName => "Holy Chant";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 34;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.SetTimedBlessing(eventArgs.SaveGame.Player.TimedBlessing + Program.Rng.DieRoll(24) + 12))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
