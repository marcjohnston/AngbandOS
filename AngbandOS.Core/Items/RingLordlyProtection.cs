using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingLordlyProtection : RingItemClass
    {
        public override char Character => '=';
        public override string Name => "Lordly Protection";

        public override int[] Chance => new int[] { 5, 0, 0, 0 };
        public override int Cost => 100000;
        public override bool FreeAct => true;
        public override string FriendlyName => "Lordly Protection";
        public override bool HoldLife => true;
        public override int Level => 100;
        public override int[] Locale => new int[] { 100, 0, 0, 0 };
        public override bool ResDisen => true;
        public override bool ResPois => true;
        public override int? SubCategory => 48;
        public override int Weight => 2;
    }
}
