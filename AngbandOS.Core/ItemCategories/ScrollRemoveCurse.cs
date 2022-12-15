using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollRemoveCurse : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Remove Curse";

        public override int[] Chance => new int[] { 1, 2, 2, 0 };
        public override int Cost => 100;
        public override string FriendlyName => "Remove Curse";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 20, 40, 0 };
        public override int? SubCategory => 14;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.RemoveCurse())
            {
                eventArgs.SaveGame.MsgPrint("You feel as if someone is watching over you.");
                eventArgs.Identified = true;
            }
        }
    }
}
