using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollRumour : ScrollItemClass
    {
        private ScrollRumour(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Rumour";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 10;
        public override string FriendlyName => "Rumour";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => 51;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("There is message on the scroll. It says:");
            eventArgs.SaveGame.MsgPrint(null);
            eventArgs.SaveGame.GetRumour();
            eventArgs.Identified = true;
        }
    }
}
