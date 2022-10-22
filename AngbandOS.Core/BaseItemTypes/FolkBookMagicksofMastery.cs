using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FolkBookMagicksofMastery : FolkBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "[Magicks of Mastery]";

        public override int Chance1 => 1;
        public override int Cost => 2500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Magicks of Mastery]";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 3;
        public override int Weight => 30;
    }
}
