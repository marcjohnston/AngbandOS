using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollDispelUndead : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Dispel Undead";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override string FriendlyName => "Dispel Undead";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 42;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.DispelUndead(60))
            {
                eventArgs.Identified = true;
            }
        }
    }
}