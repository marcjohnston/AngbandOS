using AngbandOS.Core.EventArgs;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollTreasureDetection : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Treasure Detection";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 15;
        public override string FriendlyName => "Treasure Detection";
        public override int? SubCategory => 26;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.DetectTreasure())
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.DetectObjectsGold())
            {
                eventArgs.Identified = true;
            }
        }
    }
}
