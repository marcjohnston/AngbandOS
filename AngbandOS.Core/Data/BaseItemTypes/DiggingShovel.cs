using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class DiggingShovel : DiggingItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Shovel";

        public override int Chance1 => 16;
        public override int Cost => 10;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Shovel~";
        public override int Level => 1;
        public override int Locale1 => 5;
        public override int Pval => 1;
        public override bool ShowMods => true;
        public override int? SubCategory => 1;
        public override bool Tunnel => true;
        public override int Weight => 60;
    }
}
