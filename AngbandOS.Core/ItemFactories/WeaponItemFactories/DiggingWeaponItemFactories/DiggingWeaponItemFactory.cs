// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class DiggingWeaponItemFactory : WeaponItemFactory
{
    /// <summary>
    /// Returns the digger inventory slot for shovels.
    /// </summary>
    public override int WieldSlot => InventorySlot.Digger;
    public DiggingWeaponItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.ItemClasses.Get(nameof(DiggersItemClass));
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        base.ApplyMagic(item, level, power, null);
        if (power > 1)
        {
            item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfDiggingRareItem));
        }
        else if (power < -1)
        {
            item.TypeSpecificValue = 0 - (5 + Game.DieRoll(5));
        }
        else if (power < 0)
        {
            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
        }
    }
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.InventorySlots.Get(nameof(DiggerInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Digging;
    public override int PackSort => 31;
    public override ColorEnum Color => ColorEnum.Grey;
    public override bool GetsDamageMultiplier => true;
}
