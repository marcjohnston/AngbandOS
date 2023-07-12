// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class BootsArmorItemFactory : ArmourItemFactory
{
    public BootsArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<FeetInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Boots;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override int PackSort => 27;

    public override ColourEnum Colour => ColourEnum.BrightBrown;
}
