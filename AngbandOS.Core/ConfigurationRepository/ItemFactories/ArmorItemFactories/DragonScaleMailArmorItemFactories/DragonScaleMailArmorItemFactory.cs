// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class DragonScaleMailArmorItemFactory : ArmorItemFactory 
{
    /// <summary>
    /// Returns the on-body inventory slot for scale mail.
    /// </summary>
    public override int WieldSlot => InventorySlot.OnBody;


    /// <summary>
    /// Applies special magic to dragon scale mail armor.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(item, level, power, null);

            SaveGame.TreasureRating += 30;
        }
    }

    public DragonScaleMailArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(DragonScaleMailsItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(OnBodyInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.DragArmor;
    public override int PackSort => 19;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.Grey;
}
