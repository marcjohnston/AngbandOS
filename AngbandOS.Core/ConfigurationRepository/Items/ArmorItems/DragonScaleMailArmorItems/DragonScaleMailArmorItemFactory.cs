// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class DragonScaleMailArmorItemFactory : ArmorItemFactory 
{
    public DragonScaleMailArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(DragonScaleMailsItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(BodyInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.DragArmor;
    public override int PackSort => 19;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.Grey;
}
