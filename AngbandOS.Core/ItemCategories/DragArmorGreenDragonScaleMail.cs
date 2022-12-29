using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DragArmorGreenDragonScaleMail : DragArmorItemClass
    {
        private DragArmorGreenDragonScaleMail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.Green;
        public override string Name => "Green Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 80000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Green Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override bool ResPois => true;
        public override int? SubCategory => 5;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
    }
}
