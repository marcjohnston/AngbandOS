namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class FlaskItemClass : ItemClass
    {
        public FlaskItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Flask;
        public override bool HatesCold => true;
        public override Colour Colour => Colour.Yellow;
        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 5)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 20)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }
    }
}
