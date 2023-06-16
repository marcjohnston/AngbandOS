namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ScrollItemClass : ItemFactory, IFlavour
{
    public ScrollItemClass(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the scroll flavours repository because scrolls have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavourRepository() => SaveGame.ScrollFlavours;

    /// <inheritdoc/>
    public Flavour Flavour { get; set; }

    public override bool EasyKnow => true;
    public override int PackSort => 12;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Scroll;
    public override int BaseValue => 20;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override Colour Colour => Colour.BrightBeige;

    public abstract void Read(ReadScrollEvent eventArgs);
}
