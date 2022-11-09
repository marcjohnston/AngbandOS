using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PolearmLance : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Lance";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 230;
        public override int Dd => 2;
        public override int Ds => 8;
        public override string FriendlyName => "& Lance~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 20;
        public override int Weight => 300;
    }
}
