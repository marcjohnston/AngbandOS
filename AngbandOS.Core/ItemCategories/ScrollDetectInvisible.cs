using AngbandOS.Core.EventArgs;
using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollDetectInvisible : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Detect Invisible";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 15;
        public override string FriendlyName => "Detect Invisible";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => 30;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.DetectMonstersInvis())
            {
                eventArgs.Identified = true;
            }
        }
    }
}