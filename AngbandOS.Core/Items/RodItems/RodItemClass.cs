namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class RodItemClass : ItemFactory
    {
        public RodItemClass(SaveGame saveGame) : base(saveGame) { }
        public abstract bool RequiresAiming { get; }
        public override bool EasyKnow => true;
        public override bool HasFlavor => true;
        public override int PackSort => 13;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Rod;
        public override int BaseValue => 90;
        public override Colour Colour => Colour.Turquoise;
        public abstract void Execute(ZapRodEvent zapRodEvent);
    }
}
