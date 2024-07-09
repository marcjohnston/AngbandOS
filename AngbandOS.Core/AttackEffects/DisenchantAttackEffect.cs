// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class DisenchantAttackEffect : AttackEffect
{
    private DisenchantAttackEffect(Game game) : base(game) { }
    public override int Power => 20;
    public override string Description => "disenchant";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Disenchantment might ruin our items
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        if (!Game.HasDisenchantResistance)
        {
            if (Game.RunSuccessByChanceScript(nameof(ApplyDisenchantScript)))
            {
                obvious = true;
            }
        }
        Game.UpdateSmartLearn(monster, Game.SingletonRepository.Get<SpellResistantDetection>(nameof(DisenSpellResistantDetection)));
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Get<Projectile>(nameof(DisenchantProjectile));
    }
}