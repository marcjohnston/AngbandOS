// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class UnBonusAttackEffect : AttackEffect
{
    private UnBonusAttackEffect(Game game) : base(game) { }
    public override int Power => 20;
    public override string Description => "disenchant";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Disenchantment might ruin our items
        Game.TakeHit(damage, monsterDescription);
        if (!Game.HasDisenchantResistance)
        {
            if (Game.RunSuccessfulScript(nameof(ApplyDisenchantScript)))
            {
                obvious = true;
            }
        }
        Game.UpdateSmartLearn(monster, Game.SingletonRepository.SpellResistantDetections.Get(nameof(DisenSpellResistantDetection)));
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Projectiles.Get(nameof(DisenchantProjectile));
    }
}