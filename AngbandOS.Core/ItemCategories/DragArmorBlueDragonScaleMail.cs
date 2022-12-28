using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DragArmorBlueDragonScaleMail : DragArmorItemClass
    {
        public DragArmorBlueDragonScaleMail(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '[';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Blue Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 35000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Blue Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override bool ResElec => true;
        public override int? SubCategory => 2;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
    }
}
