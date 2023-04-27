namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class WandItemClass : ItemFactory, IFlavour
    {
        public WandItemClass(SaveGame saveGame) : base(saveGame) { }

        /// <summary>
        /// Returns the want flavours repository because wands have flavours that need to be identified.
        /// </summary>
        public IEnumerable<Flavour> Flavours => SaveGame.SingletonRepository.WandFlavours;

        public override int PackSort => 14;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Wand;
        public abstract bool ExecuteActivation(SaveGame saveGame, int dir);
        public override int BaseValue => 50;
        public override bool HatesElectricity => true;

        //public override bool IsCharged => true;
        public override Colour Colour => Colour.Chartreuse;
    }
}
