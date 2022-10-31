using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class LifeBookHighMass : LifeBookItemCategory
    {
        public override char Character => '?';
        public override string Name => "[High Mass]";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[High Mass]";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 1;
        public override int Weight => 30;
        public override bool KindIsGood => false;
    }
}
