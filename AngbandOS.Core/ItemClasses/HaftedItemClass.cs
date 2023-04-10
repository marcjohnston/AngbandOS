namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class HaftedItemClass : MeleeWeaponItemClass
    {
        public HaftedItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int PackSort => 30;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Hafted;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;


    }
}
