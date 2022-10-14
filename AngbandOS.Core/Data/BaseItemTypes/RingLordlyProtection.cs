using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingLordlyProtection : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Lordly Protection";

        public override int Chance1 => 5;
        public override int Cost => 100000;
        public override bool FreeAct => true;
        public override string FriendlyName => "Lordly Protection";
        public override bool HoldLife => true;
        public override int Level => 100;
        public override int Locale1 => 100;
        public override bool ResDisen => true;
        public override bool ResPois => true;
        public override int? SubCategory => 48;
        public override int Weight => 2;
    }
}
