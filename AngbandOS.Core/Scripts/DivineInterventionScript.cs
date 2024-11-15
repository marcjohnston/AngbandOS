// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DivineInterventionScript : Script, IScript
{
    private DivineInterventionScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(HolyFireProjectile));
        projectile.Fire(0, 1, Game.MapY.IntValue, Game.MapX.IntValue, 777, ProjectionFlag.ProjectKill);
        Game.DispelMonsters(Game.ExperienceLevel.IntValue * 4);
        Game.RunScript(nameof(SlowMonstersScript));
        Game.StunMonsters(Game.ExperienceLevel.IntValue * 4);
        Game.ConfuseMonsters(Game.ExperienceLevel.IntValue * 4);
        Game.TurnMonsters(Game.ExperienceLevel.IntValue * 4);
        Game.StasisMonsters(Game.ExperienceLevel.IntValue * 4);
        Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterFilter>(nameof(CthuloidMonsterFilter)), true);
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
