using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ChestSmallWooden : ChestItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Small wooden chest";

        public override int Chance1 => 1;
        public override int Cost => 20;
        public override int Dd => 2;
        public override int Ds => 3;
        public override string FriendlyName => "& Small wooden chest~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 1;
        public override int Weight => 250;
    }
}
