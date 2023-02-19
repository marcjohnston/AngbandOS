namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class JunkItemClass : ItemClass
    {
        public JunkItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Junk;
        public override bool HatesAcid => true;

        public override int PercentageBreakageChance => 100;
        public override int PackSort => 38;
    }
}
