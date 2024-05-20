// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class AmuletJeweleryItemFactory : JewelleryItemFactory, IFlavorFactory
{
    public AmuletJeweleryItemFactory(Game game) : base(game) { }

    public override bool IsWearable => true;
    /// <summary>
    /// Returns the neck inventory slot for amulets.
    /// </summary>
    public override int WieldSlot => InventorySlot.Neck;

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavor.
    /// </summary>
    public IFlavorFactory FlavorFactory => (IFlavorFactory)this;

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        if (item.FixedArtifact != null && isFlavorAware)
        {
            return base.GetDescription(item, includeCountPrefix, isFlavorAware);
        }
        string flavor = item.IdentityIsStoreBought ? "" : $"{FlavorFactory.Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {item.Factory.FriendlyName}" : "";
        string name = $"{flavor}{Game.CountPluralize("Amulet", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    protected override string ItemClassName => nameof(AmuletsItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(NeckInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Amulet;
    public override int PackSort => 17;
    public override int BaseValue => 45;
    public override ColorEnum Color => ColorEnum.Orange;

    /// <summary>
    /// Returns the amulet flavors repository because amulets have flavors that need to be identified.
    /// </summary>
    public IEnumerable<Flavor>? GetFlavorRepository() => Game.SingletonRepository.Get<AmuletReadableFlavor>();

    /// <inheritdoc/>
    public Flavor Flavor { get; set; }
}
