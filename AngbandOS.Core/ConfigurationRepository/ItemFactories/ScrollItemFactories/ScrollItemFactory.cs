// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class ScrollItemFactory : ItemFactory, IFlavor
{
    public ScrollItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(ScrollsItemClass));

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavor FlavourFactory => (IFlavor)this;

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavourAware)
    {
        string flavour = item.IdentityIsStoreBought ? "" : $" titled \"{FlavourFactory.Flavor.Name}\"";
        string ofName = isFlavourAware ? $" of {FriendlyName}" : "";
        string name = $"{CountPluralize("Scroll", item.Count)}{flavour}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    /// <summary>
    /// Returns the scroll flavours repository because scrolls have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavor>? GetFlavorRepository() => SaveGame.ScrollFlavours;

    public override int GetAdditionalMassProduceCount(Item item)
    {
        int cost = item.Value();
        if (cost <= 60)
        {
            return item.MassRoll(3, 5);
        }
        if (cost <= 240)
        {
            return item.MassRoll(1, 5);
        }
        return 0;
    }

    public override int PercentageBreakageChance => 50;
    public override bool CanBeRead => true;

    /// <inheritdoc/>
    public Flavor Flavor { get; set; }

    public override bool EasyKnow => true;
    public override int PackSort => 12;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Scroll;
    public override int BaseValue => 20;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.BrightBeige;

    public abstract void Read(ReadScrollEvent eventArgs);
}
