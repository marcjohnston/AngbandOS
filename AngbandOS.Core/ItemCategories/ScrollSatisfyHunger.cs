using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollSatisfyHunger : ScrollItemClass
    {
        public ScrollSatisfyHunger(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '?';
        public override string Name => "Satisfy Hunger";

        public override int[] Chance => new int[] { 1, 1, 1, 1 };
        public override int Cost => 10;
        public override string FriendlyName => "Satisfy Hunger";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 20, 50, 75 };
        public override int? SubCategory => 32;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.SetFood(Constants.PyFoodMax - 1))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
