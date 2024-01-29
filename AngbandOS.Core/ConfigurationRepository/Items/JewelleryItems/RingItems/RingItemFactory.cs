// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class RingItemFactory : JewelleryItemFactory, IFlavour
{
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
        string ofName = item.IsFlavourAware() ? $" of {FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Ring", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    /// <summary>
    /// Returns either the right or left hand inventory slot for rings.
    /// </summary>
    public override int WieldSlot
    {
        get
        {
            if (SaveGame.GetInventoryItem(InventorySlot.RightHand) == null)
            {
                return InventorySlot.RightHand;
            }
            return InventorySlot.LeftHand;
        }
    }

    public RingItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(RingsItemClass));

    /// <summary>
    /// Returns the ring flavours repository because rings have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour> GetFlavorRepository() => SaveGame.SingletonRepository.RingFlavours;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }

    public override BaseInventorySlot BaseWieldSlot
    {
        get
        {
            BaseInventorySlot rightHand = SaveGame.SingletonRepository.InventorySlots.Get(nameof(RightHandInventorySlot));
            if (rightHand.Count == 0)
            {
                return rightHand;
            }
            return SaveGame.SingletonRepository.InventorySlots.Get(nameof(LeftHandInventorySlot));
        }
    }
    public override int PackSort => 16;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Ring;
    public override int BaseValue => 45;
    public override bool HatesElectricity => true;
    public override ColorEnum Color => ColorEnum.Gold;
}
