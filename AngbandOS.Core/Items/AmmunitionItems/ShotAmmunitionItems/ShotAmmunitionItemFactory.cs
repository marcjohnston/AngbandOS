namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ShotAmmunitionItemFactory : AmmunitionItemClass
    {
        public ShotAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Shot;
        public override int PackSort => 35;
        public override Colour Colour => Colour.BrightBrown;
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
    }
}
