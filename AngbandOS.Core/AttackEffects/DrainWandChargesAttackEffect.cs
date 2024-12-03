// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class DrainWandChargesAttackEffect : AttackEffect
{
    private DrainWandChargesAttackEffect(Game game) : base(game) { }
    public override int Power => 15;
    public override string Description => "drain charges";

    public bool DrainChargesMonsterAttack(Item item, Monster monster, ref bool obvious) // TODO: obvious needs to be in an event 
    {
        if (item.WandChargesRemaining == 0)
        {
            return false;
        }
        Game.MsgPrint("Energy drains from your pack!");
        obvious = true;
        int j = monster.Level;
        monster.Health += j * item.WandChargesRemaining * item.Count;
        if (monster.Health > monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
        }
        item.WandChargesRemaining = 0;
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