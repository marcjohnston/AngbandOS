using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollObjectDetection : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Object Detection";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 15;
        public override string FriendlyName => "Object Detection";
        public override int? SubCategory => 27;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.DetectObjectsNormal())
            {
                eventArgs.Identified = true;
            }
        }
    }
}
