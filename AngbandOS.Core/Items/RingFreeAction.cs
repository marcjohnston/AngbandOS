using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingFreeAction : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Free Action";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1500;
        public override bool EasyKnow => true;
        public override bool FreeAct => true;
        public override string FriendlyName => "Free Action";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 21;
        public override int Weight => 2;
    }
}