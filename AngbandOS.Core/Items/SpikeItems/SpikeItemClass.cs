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

    }
}
