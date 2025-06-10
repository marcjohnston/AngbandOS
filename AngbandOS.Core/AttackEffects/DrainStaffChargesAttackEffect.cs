// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class DrainStaffChargesAttackEffect : AttackEffect
{
    private DrainStaffChargesAttackEffect(Game game) : base(game) { }
    public override int Power => 15;
    public override string Description => "drain charges";

    /// <summary>
    /// Drains charges from the item and returns true, if charges were drained.
    /// Drains charges from the item and returns true, if charges were drained; false, otherwise.  Returns false, by default.
    /// </summary>
    /// <param name="monster"></param>
    /// <param name="obvious"></param>
    /// <returns></returns>
    private bool DrainChargesMonsterAttack(Item item, Monster monster, ref bool obvious) // TODO: obvious needs to be in an event 
    {
        if (item.StaffChargesRemaining == 0)
        {
            return false;
        }
        Game.MsgPrint("Energy drains from your pack!");
        obvious = true;
        int j = monster.Level;
        monster.Health += j * item.StaffChargesRemaining * item.StackCount;
        if (monster.Health > monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
        }
        item.StaffChargesRemaining = 0;
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        return true;
    }

    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked) // TODO: These need to be in an event
    {
        // Unpower might drain charges from our items
        Game.TakeHit(damage, monster.IndefiniteVisibleName);

        // We will attempt up to 10 selections on items.
        for (int k = 0; k < 10; k++)
        {
            WieldSlot packInventorySlot = Game.SingletonRepository.Get<WieldSlot>(nameof(PackWieldSlot));
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = Game.GetInventoryItem(i);
            if (item != null && DrainChargesMonsterAttack(item, monster, ref obvious))
            {
                return;
            }
        }
    }

    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Get<Projectile>(nameof(DisenchantProjectile));
    }
}