namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SwordItemClass : MeleeWeaponItemClass
    {
        public SwordItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Sword;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;


    }
}
