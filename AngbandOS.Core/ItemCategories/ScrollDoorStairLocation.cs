using AngbandOS.Core.EventArgs;
using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollDoorStairLocation : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Door/Stair Location";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 35;
        public override string FriendlyName => "Door/Stair Location";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 10, 15, 0 };
        public override int? SubCategory => 29;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.DetectDoors())
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.DetectStairs())
            {
                eventArgs.Identified = true;
            }
        }
    }
}