using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollMonsterConfusion : ScrollItemClass
    {
        private ScrollMonsterConfusion(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Monster Confusion";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 30;
        public override string FriendlyName => "Monster Confusion";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 36;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (!eventArgs.SaveGame.Player.HasConfusingTouch)
            {
                eventArgs.SaveGame.MsgPrint("Your hands begin to glow.");
                eventArgs.SaveGame.Player.HasConfusingTouch = true;
                eventArgs.Identified = true;
            }
        }
    }
}
