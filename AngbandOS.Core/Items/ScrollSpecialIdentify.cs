using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialIdentify : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "*Identify*";

        public override int[] Chance => new int[] { 1, 2, 1, 1 };
        public override int Cost => 1000;
        public override string FriendlyName => "*Identify*";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 50, 80, 100 };
        public override int? SubCategory => 13;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.Identified = true;
            if (!eventArgs.SaveGame.IdentifyFully())
            {
                eventArgs.UsedUp = false;
            }
        }
    }
}