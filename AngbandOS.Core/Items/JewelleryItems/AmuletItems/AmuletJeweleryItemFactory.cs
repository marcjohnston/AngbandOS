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
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<NeckInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Amulet;
    public override int PackSort => 17;
    public override int BaseValue => 45;
    public override Colour Colour => Colour.Orange;

    /// <summary>
    /// Returns the amulet flavours repository because amulets have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavourRepository() => SaveGame.SingletonRepository.AmuletFlavours;

    /// <inheritdoc/>
    public Flavour Flavour { get; set; }
}
