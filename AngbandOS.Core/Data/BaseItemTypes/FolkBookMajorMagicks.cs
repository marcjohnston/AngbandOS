using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FolkBookMajorMagicks : FolkBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "FolkBook:[Major Magicks]";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Major Magicks]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 2;
        public override int Weight => 30;
    }
}
