using AngbandOS.Core.EventArgs;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollTeleportLevel : ScrollItemClass
    {
        private ScrollTeleportLevel(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Teleport Level";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override string FriendlyName => "Teleport Level";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 10;
        public override int Weight => 5;
        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.TeleportPlayerLevel();
            eventArgs.Identified = true;
        }
    }
}
