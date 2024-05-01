// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class DrainChargesAttackEffect : AttackEffect
{
    private DrainChargesAttackEffect(Game game) : base(game) { }
    public override int Power => 15;
    public override string Description => "drain charges";

    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked) // TODO: These need to be in an event
    {
        // Unpower might drain charges from our items
        Game.TakeHit(damage, monster.IndefiniteVisibleName);

        // We will attempt up to 10 selections on items.
        for (int k = 0; k < 10; k++)
        {
            BaseInventorySlot packInventorySlot = Game.SingletonRepository.Get<BaseInventorySlot>(nameof(PackInventorySlot));
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = Game.GetInventoryItem(i);
            if (item != null && item.DrainChargesMonsterAttack(monster, ref obvious))
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