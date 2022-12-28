using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingTulkas : RingItemClass
    {
        public RingTulkas(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '=';
        public override string Name => "Tulkas";

        public override int Cost => 150000;
        public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 90;
        public override int? SubCategory => 33;
        public override int Weight => 2;
    }
}
