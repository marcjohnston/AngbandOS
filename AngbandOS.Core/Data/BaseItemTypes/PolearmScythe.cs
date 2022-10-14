using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PolearmScythe : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Scythe";

        public override int Chance1 => 1;
        public override int Cost => 800;
        public override int Dd => 5;
        public override int Ds => 3;
        public override string FriendlyName => "& Scythe~";
        public override int Level => 45;
        public override int Locale1 => 45;
        public override bool ShowMods => true;
        public override int? SubCategory => 17;
        public override int Weight => 250;
    }
}
