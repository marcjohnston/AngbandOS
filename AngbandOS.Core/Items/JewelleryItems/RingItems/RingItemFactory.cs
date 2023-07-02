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
    public RingItemFactory(SaveGame saveGame) : base(saveGame) { }

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
            BaseInventorySlot rightHand = SaveGame.SingletonRepository.InventorySlots.Get<RightHandInventorySlot>();
            if (rightHand.Count == 0)
            {
                return rightHand;
            }
            return SaveGame.SingletonRepository.InventorySlots.Get<LeftHandInventorySlot>();
        }
    }
    public override int PackSort => 16;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Ring;
    public override int BaseValue => 45;
    public override bool HatesElectricity => true;
    public override Colour Colour => Colour.Gold;
}
