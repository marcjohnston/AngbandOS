using AngbandOS.Core.EventArgs;
using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollTrapDetection : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Trap Detection";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 35;
        public override string FriendlyName => "Trap Detection";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 10, 0, 0 };
        public override int? SubCategory => 28;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.DetectTraps())
            {
                eventArgs.Identified = true;
            }
        }
    }
}