// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class BootsArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Returns the feet inventory slot for boots.
    /// </summary>
    public override int WieldSlot => InventorySlot.Feet;

    public BootsArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(BootsItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(FeetInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Boots;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override int PackSort => 27;

    public override ColorEnum Color => ColorEnum.BrightBrown;
}
