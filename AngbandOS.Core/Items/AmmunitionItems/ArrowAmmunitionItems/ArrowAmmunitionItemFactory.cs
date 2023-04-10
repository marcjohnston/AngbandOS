namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ArrowItemFactory : AmmunitionItemClass
    {
        public ArrowItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Arrow;
        public override int PackSort => 34;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;
        /// <summary>
        /// Returns true, for all arrows.
        /// </summary>
        public override bool KindIsGood => true;

        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 5)
            {
                return MassRoll(5, 5);
            }
            if (cost <= 50)
            {
                return MassRoll(5, 5);
            }
            if (cost <= 500)
            {
                return MassRoll(5, 5);
            }
            return 0;
        }

        public override Colour Colour => Colour.BrightBrown;
    }
}
