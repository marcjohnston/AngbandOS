// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class ParalyzeAttackEffect : AttackEffect
{
    private ParalyzeAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 2;
    public override string Description => "paralyze";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        if (damage == 0)
        {
            damage = 1;
        }
        SaveGame.TakeHit(damage, monsterDescription);
        if (SaveGame.HasFreeAction)
        {
            SaveGame.MsgPrint("You are unaffected!");
            obvious = true;
        }
        else if (SaveGame.RandomLessThan(100) < SaveGame.SkillSavingThrow)
        {
            SaveGame.MsgPrint("You resist the effects!");
            obvious = true;
        }
        else
        {
            if (SaveGame.ParalysisTimer.AddTimer(3 + SaveGame.DieRoll(monsterLevel)))
            {
                obvious = true;
            }
        }
        SaveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get(nameof(FreeSpellResistantDetection)));
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = SaveGame.SingletonRepository.Projectiles.Get(nameof(OldSleepProjectile));
        damage = monster.Race.Level;
    }
}