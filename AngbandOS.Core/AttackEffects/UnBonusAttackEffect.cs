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
    public override int Power => 20;
    public override string Description => "disenchant";
    public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Disenchantment might ruin our items
        saveGame.TakeHit(damage, monsterDescription);
        if (!saveGame.HasDisenchantResistance)
        {
            if (saveGame.ApplyDisenchant())
            {
                obvious = true;
            }
        }
        saveGame.Level.UpdateSmartLearn(monster, new DisenSpellResistantDetection());
    }
    public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = saveGame.SingletonRepository.Projectiles.Get<DisenchantProjectile>();
    }
}