using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollTrapDoorDestruction : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Trap/Door Destruction";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override string FriendlyName => "Trap/Door Destruction";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 39;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.DestroyDoorsTouch())
            {
                eventArgs.Identified = true;
            }
        }
    }
}