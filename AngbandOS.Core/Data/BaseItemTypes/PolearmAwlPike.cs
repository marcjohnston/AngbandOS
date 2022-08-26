using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PolearmAwlPike : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Awl-Pike";

        public override int Chance1 => 1;
        public override int Cost => 340;
        public override int Dd => 1;
        public override int Ds => 8;
        public override string FriendlyName => "& Awl-Pike~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ShowMods => true;
        public override int SubCategory => 4;
        public override int Weight => 160;
    }
}
