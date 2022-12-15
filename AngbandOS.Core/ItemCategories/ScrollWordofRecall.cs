using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollWordOfRecall : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Word of Recall";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 150;
        public override string FriendlyName => "Word of Recall";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 11;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.Player.ToggleRecall();
            eventArgs.Identified = true;
        }
    }
}
