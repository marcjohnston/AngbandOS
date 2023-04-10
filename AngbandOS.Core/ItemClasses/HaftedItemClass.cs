namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class HaftedItemClass : MeleeWeaponItemClass
    {
        public HaftedItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Hafted;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;


    }
}
