// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class AcidAttackEffect : AttackEffect
{
    public override int Power => 0;
    public override string Description => "shoot acid";
    public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        saveGame.MsgPrint("You are covered in acid!");
        saveGame.AcidDam(damage, monsterDescription);
        saveGame.UpdateSmartLearn(monster, new AcidSpellResistantDetection());
    }
    public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = saveGame.SingletonRepository.Projectiles.Get<AcidProjectile>();
    }
}