namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class BottleItemClass : ItemClass
    {
        public BottleItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bottle;
        public override bool HatesCold => true;
        public override bool HatesAcid => true;

    }
}
