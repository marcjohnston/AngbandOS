using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollCarnage : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Carnage";

        public override int[] Chance => new int[] { 4, 4, 0, 0 };
        public override int Cost => 750;
        public override string FriendlyName => "Carnage";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 80, 0, 0 };
        public override int? SubCategory => 44;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.Carnage(true);
            eventArgs.Identified = true;
        }
    }
}