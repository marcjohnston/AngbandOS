using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodSleepMonster : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Sleep Monster";

        public override int Chance1 => 1;
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Sleep Monster";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 16;
        public override int Weight => 15;
    }
}
