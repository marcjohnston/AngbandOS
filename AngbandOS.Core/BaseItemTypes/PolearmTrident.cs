using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PolearmTrident : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Trident";

        public override int Chance1 => 1;
        public override int Cost => 120;
        public override int Dd => 1;
        public override int Ds => 8;
        public override string FriendlyName => "& Trident~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool ShowMods => true;
        public override int? SubCategory => 5;
        public override int Weight => 70;
    }
}
