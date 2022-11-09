using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodPerception : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Perception";

        public override int[] Chance => new int[] { 8, 8, 0, 0 };
        public override int Cost => 13000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Perception";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 100, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 15;
    }
}
