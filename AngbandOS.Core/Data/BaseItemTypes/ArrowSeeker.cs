using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ArrowSeeker : ArrowItemCategory
    {
        public override char Character => '{';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Arrow:Seeker Arrow";

        public override int Chance1 => 2;
        public override int Cost => 20;
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "& Seeker Arrow~";
        public override int Level => 55;
        public override int Locale1 => 55;
        public override bool ShowMods => true;
        public override int SubCategory => 2;
        public override int Weight => 2;
    }
}
