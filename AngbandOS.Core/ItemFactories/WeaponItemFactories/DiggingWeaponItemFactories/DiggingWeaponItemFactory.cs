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
    protected override string ItemClassName => nameof(DiggersItemClass);
    public override bool CanTunnel => true;
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        if (power == 0)
        {
            return;
        }

        int tohit1 = Game.DieRoll(5) + item.GetBonusValue(5, level);
        int todam1 = Game.DieRoll(5) + item.GetBonusValue(5, level);
        int tohit2 = item.GetBonusValue(10, level);
        int todam2 = item.GetBonusValue(10, level);
        if (power > 0)
        {
            item.BonusHit += tohit1;
            item.BonusDamage += todam1;
            if (power > 1)
            {
                item.BonusHit += tohit2;
                item.BonusDamage += todam2;
            }
        }
        else if (power < 0)
        {
            item.BonusHit -= tohit1;
            item.BonusDamage -= todam1;
            if (power < -1)
            {
                item.BonusHit -= tohit2;
                item.BonusDamage -= todam2;
            }
            if (item.BonusHit + item.BonusDamage < 0)
            {
                item.IsCursed = true;
            }
        }
        if (power > 1)
        {
            item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(WeaponOfDiggingRareItem));
        }
        else if (power < -1)
        {
            item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(TerribleWeaponOfDiggingRareItem));
        }
        else if (power < 0)
        {
            item.BonusTunnel = 0 - item.BonusTunnel;
        }
    }
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(DiggerInventorySlot));
    public override int PackSort => 31;
    public override ColorEnum Color => ColorEnum.Grey;
    public override bool GetsDamageMultiplier => true;
}
