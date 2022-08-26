using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class LightStarEssenceElendil : LightItemCategory
    {
        public override char Character => '*';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Light:Star Essence*";

        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Star Essence~";
        public override bool InstaArt => true;
        public override int Level => 30;
        public override int SubCategory => 5;
        public override int Weight => 5;
    }
}
