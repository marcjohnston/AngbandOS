namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ShotItemClass : AmmunitionItemClass
    {
        public ShotItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Shot;
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

        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.StatsAreSame(other))
            {
                return false;
            }
            return true;
        }


    }
}
