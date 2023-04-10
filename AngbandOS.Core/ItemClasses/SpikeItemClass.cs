namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SpikeItemClass : ItemFactory
    {
        public SpikeItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Spike;
        public override int PackSort => 37;
        public override Colour Colour => Colour.Grey;

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
