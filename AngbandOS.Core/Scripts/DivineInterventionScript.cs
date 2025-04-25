// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DivineInterventionScript : Script, IScript, ICastSpellScript
{
    private DivineInterventionScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.HolyFireProjectile));
        projectile.Fire(0, 1, Game.MapY.IntValue, Game.MapX.IntValue, 777, kill: true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false, stop: false);
        Game.RunScript(nameof(DispelAllAtLos4xProjectileScript));
        Game.RunScript(nameof(OldSlowAtLos1xProjectileScript));
        Game.RunScript(nameof(StunAtLos4xProjectileScript));
        Game.RunScript(nameof(OldConfuseAtLos4xProjectileScript));
        Game.RunScript(nameof(TurnAllAtLos4xProjectileScript));
        Game.RunIdentifiedScript(nameof(StasisAtLos4xProjectileScript));
        Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(CthuloidMonsterRaceFilter)), true, true);
        Game.SuperheroismTimer.AddTimer(Game.DieRoll(25) + 25);
        Game.RestoreHealth(300);
        if (Game.HasteTimer.Value == 0)
        {
            Game.HasteTimer.SetTimer(Game.DieRoll(20 + Game.ExperienceLevel.IntValue) + Game.ExperienceLevel.IntValue);
        }
        else
        {
            Game.HasteTimer.AddTimer(Game.DieRoll(5));
        }
        Game.FearTimer.ResetTimer();
    }
}
