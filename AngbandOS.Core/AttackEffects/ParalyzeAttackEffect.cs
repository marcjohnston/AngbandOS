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
    private ParalyzeAttackEffect(Game game) : base(game) { }
    public override int Power => 2;
    public override string Description => "paralyze";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        if (damage == 0)
        {
            damage = 1;
        }
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        if (Game.HasFreeAction)
        {
            Game.MsgPrint("You are unaffected!");
            obvious = true;
        }
        else if (Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
            obvious = true;
        }
        else
        {
            if (Game.ParalysisTimer.AddTimer(3 + Game.DieRoll(monster.Level)))
            {
                obvious = true;
            }
        }
        Game.UpdateSmartLearn(monster, Game.SingletonRepository.Get<SpellResistantDetection>(nameof(FreeSpellResistantDetection)));
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Get<Projectile>(nameof(OldSleepProjectile));
        damage = monster.Race.Level;
    }
}