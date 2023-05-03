namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class RodItemFactory : ItemFactory, IFlavour
    {
        public RodItemFactory(SaveGame saveGame) : base(saveGame) { }

        /// <summary>
        /// Returns the rod flavours repository because rods have flavours that need to be identified.
        /// </summary>
        public IEnumerable<Flavour>? GetFlavourRepository() => SaveGame.SingletonRepository.RodFlavours;

        /// <inheritdoc/>
        public Flavour Flavour { get; set; }

        public abstract bool RequiresAiming { get; }
        public override bool EasyKnow => true;
        public override int PackSort => 13;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Rod;
        public override int BaseValue => 90;
        public override Colour Colour => Colour.Turquoise;
        public abstract void Execute(ZapRodEvent zapRodEvent);
    }
}
