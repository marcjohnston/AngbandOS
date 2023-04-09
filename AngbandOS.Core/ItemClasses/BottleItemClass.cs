namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class BottleItemClass : ItemFactory
    {
        public BottleItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bottle;
        public override bool HatesCold => true;
        public override bool HatesAcid => true;

    }
}
