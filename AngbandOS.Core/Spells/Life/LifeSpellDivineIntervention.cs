// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellDivineIntervention : Spell
{
    private LifeSpellDivineIntervention(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.Project(0, 1, SaveGame.MapY, SaveGame.MapX, 777, SaveGame.SingletonRepository.Projectiles.Get<HolyFireProjectile>(),
            ProjectionFlag.ProjectKill);
        SaveGame.DispelMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.SlowMonsters();
        SaveGame.StunMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.ConfuseMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.TurnMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.StasisMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, new CthuloidMonsterSelector(), true);
        SaveGame.TimedSuperheroism.AddTimer(SaveGame.Rng.DieRoll(25) + 25);
        SaveGame.RestoreHealth(300);
        if (SaveGame.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.TimedHaste.SetTimer(SaveGame.Rng.DieRoll(20 + SaveGame.ExperienceLevel) + SaveGame.ExperienceLevel);
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(SaveGame.Rng.DieRoll(5));
        }
        SaveGame.TimedFear.ResetTimer();
    }

    public override string Name => "Divine Intervention";
    
    protected override string? Info()
    {
        return $"h300/d{SaveGame.ExperienceLevel * 4}+777";
    }
}