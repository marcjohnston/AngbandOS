namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class WandItemClass : ItemFactory
    {
        public WandItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool HasFlavor => true;
        public override int PackSort => 14;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Wand;
        public abstract bool ExecuteActivation(SaveGame saveGame, int dir);
        public override int BaseValue => 50;
        public override bool HatesElectricity => true;

        //public override bool IsCharged => true;
        public override Colour Colour => Colour.Chartreuse;
    }
}
