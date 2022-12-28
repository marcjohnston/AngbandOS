using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightStarEssenceElendil : LightSourceItemClass
    {
        public LightStarEssenceElendil(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '*';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Star Essence Elendil";

        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Star Essence~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 30;
        public override int? SubCategory => 5;
        public override int Weight => 5;
    }
}
