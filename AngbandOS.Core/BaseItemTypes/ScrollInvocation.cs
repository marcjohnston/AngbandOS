using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollInvocation : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Invocation";

        public override int Chance1 => 1;
        public override int Chance2 => 2;
        public override int Chance3 => 2;
        public override int Cost => 200;
        public override string FriendlyName => "Invocation";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Locale2 => 20;
        public override int Locale3 => 40;
        public override int? SubCategory => 6;
        public override int Weight => 5;
    }
}
