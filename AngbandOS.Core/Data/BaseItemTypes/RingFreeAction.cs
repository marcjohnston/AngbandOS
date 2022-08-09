using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingFreeAction : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Free Action";

        public override int Chance1 => 1;
        public override int Cost => 1500;
        public override bool EasyKnow => true;
        public override bool FreeAct => true;
        public override string FriendlyName => "Free Action";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 21;
        public override int Weight => 2;
    }
}
