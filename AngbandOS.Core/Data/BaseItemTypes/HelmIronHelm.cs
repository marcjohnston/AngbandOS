using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HelmIronHelm : HelmItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Helm:Iron Helm";

        public override int Ac => 5;
        public override int Chance1 => 1;
        public override int Cost => 75;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Iron Helm~";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 5;
        public override int Weight => 75;
    }
}
