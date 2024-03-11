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
    private DivineInterventionScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.Project(0, 1, SaveGame.MapY, SaveGame.MapX, 777, SaveGame.SingletonRepository.Projectiles.Get(nameof(HolyFireProjectile)), ProjectionFlag.ProjectKill);
        SaveGame.DispelMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.RunScript(nameof(SlowMonstersScript));
        SaveGame.StunMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.ConfuseMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.TurnMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.StasisMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(CthuloidMonsterFilter)), true);
        SaveGame.TimedSuperheroism.AddTimer(SaveGame.DieRoll(25) + 25);
        SaveGame.RestoreHealth(300);
        if (SaveGame.TimedHaste.Value == 0)
        {
            SaveGame.TimedHaste.SetTimer(SaveGame.DieRoll(20 + SaveGame.ExperienceLevel) + SaveGame.ExperienceLevel);
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(SaveGame.DieRoll(5));
        }
        SaveGame.TimedFear.ResetTimer();
    }
}
