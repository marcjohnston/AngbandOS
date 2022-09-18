using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingDexterity : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Dexterity";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override bool Dex => true;
        public override string FriendlyName => "Dexterity";
        public override bool HideType => true;
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 26;
        public override int Weight => 2;
    }
}
