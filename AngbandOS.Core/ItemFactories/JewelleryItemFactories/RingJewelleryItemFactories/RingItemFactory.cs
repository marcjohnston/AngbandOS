// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class RingItemFactory : JewelleryItemFactory, IFlavorFactory
{
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
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{Game.CountPluralize("Ring", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    /// <summary>
    /// Returns either the right or left hand inventory slot for rings.
    /// </summary>
    public override int WieldSlot
    {
        get
        {
            if (Game.GetInventoryItem(InventorySlot.RightHand) == null)
            {
                return InventorySlot.RightHand;
            }
            return InventorySlot.LeftHand;
        }
    }

    public RingItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.Get<ItemClass>(nameof(RingsItemClass));

    /// <summary>
    /// Returns the ring flavors repository because rings have flavors that need to be identified.
    /// </summary>
    public IEnumerable<Flavor> GetFlavorRepository() => Game.SingletonRepository.Get<RingReadableFlavor>();

    /// <inheritdoc/>
    public Flavor Flavor { get; set; }

    public override BaseInventorySlot BaseWieldSlot
    {
        get
        {
            BaseInventorySlot rightHand = Game.SingletonRepository.InventorySlots.Get(nameof(RightHandInventorySlot));
            if (rightHand.Count == 0)
            {
                return rightHand;
            }
            return Game.SingletonRepository.InventorySlots.Get(nameof(LeftHandInventorySlot));
        }
    }
    public override int PackSort => 16;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Ring;
    public override int BaseValue => 45;
    public override bool HatesElectricity => true;
    public override ColorEnum Color => ColorEnum.Gold;
}
