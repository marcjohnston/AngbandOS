namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class FlaskItemClass : ItemFactory
    {
        public FlaskItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Flask;
        public override bool HatesCold => true;
        public override int PackSort => 10;
        public override Colour Colour => Colour.Yellow;
    }
}
