using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FolkBookMinorMagicks : FolkBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "FolkBook:[Minor Magicks]";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Minor Magicks]";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 1;
        public override int Weight => 30;
    }
}
