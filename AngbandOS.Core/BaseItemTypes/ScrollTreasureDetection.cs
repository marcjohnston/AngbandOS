using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollTreasureDetection : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Treasure Detection";

        public override int Chance1 => 1;
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
