namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ScrollItemClass : ItemFactory
    {
        public ScrollItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override bool HasFlavor => true;
        public override int PackSort => 12;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Scroll;
        public override int BaseValue => 20;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBeige;

        public abstract void Read(ReadScrollEvent eventArgs);
    }
}
