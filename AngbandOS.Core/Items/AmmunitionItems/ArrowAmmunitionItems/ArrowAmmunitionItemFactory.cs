namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ArrowAmmunitionItemFactory : AmmunitionItemClass
    {
        public ArrowAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Arrow;
        public override int PackSort => 34;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;
        /// <summary>
        /// Returns true, for all arrows.
        /// </summary>
        public override bool KindIsGood => true;


        public override Colour Colour => Colour.BrightBrown;
    }
}
