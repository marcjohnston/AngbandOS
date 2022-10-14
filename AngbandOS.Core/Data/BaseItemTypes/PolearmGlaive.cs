using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PolearmGlaive : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Glaive";

        public override int Chance1 => 1;
        public override int Cost => 363;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Glaive~";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override bool ShowMods => true;
        public override int? SubCategory => 13;
        public override int Weight => 190;
    }
}
