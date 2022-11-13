using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightGemstone : LightSourceItemClass
    {
        public override char Character => '*';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Gemstone";

        public override int Cost => 60000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Gemstone~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 60;
        public override int? SubCategory => 6;
        public override int Weight => 5;
    }
}
