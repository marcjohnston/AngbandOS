namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class JunkItemClass : ItemFactory
    {
        public JunkItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Junk;
        public override bool HatesAcid => true;

    }
}
