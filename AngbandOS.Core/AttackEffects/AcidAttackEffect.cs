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
    private AcidAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 0;
    public override string Description => "shoot acid";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        SaveGame.MsgPrint("You are covered in acid!");
        SaveGame.AcidDam(damage, monsterDescription);
        SaveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get(nameof(AcidSpellResistantDetection)));
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = SaveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile));
    }
}