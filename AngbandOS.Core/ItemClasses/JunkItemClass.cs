namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class JunkItemClass : ItemFactory
    {
        public JunkItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int PackSort => 38;
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Junk;
        public override bool HatesAcid => true;

    }
}
