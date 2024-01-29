// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class AmuletJeweleryItemFactory : JewelleryItemFactory, IFlavour
{
    public AmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the neck inventory slot for amulets.
    /// </summary>
    public override int WieldSlot => InventorySlot.Neck;

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavour FlavourFactory => (IFlavour)this;

    public override string GetDescription(Item item, bool includeCountPrefix)
    {
        if (item.FixedArtifact != null && item.IsFlavourAware())
        {
            return base.GetDescription(item, includeCountPrefix);
        }
        string flavour = item.IdentStoreb ? "" : $"{FlavourFactory.Flavor.Name} ";
        string ofName = item.IsFlavourAware() ? $" of {item.Factory.FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Amulet", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(AmuletsItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(NeckInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Amulet;
    public override int PackSort => 17;
    public override int BaseValue => 45;
    public override ColorEnum Color => ColorEnum.Orange;

    /// <summary>
    /// Returns the amulet flavours repository because amulets have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavorRepository() => SaveGame.SingletonRepository.AmuletFlavours;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }
}
