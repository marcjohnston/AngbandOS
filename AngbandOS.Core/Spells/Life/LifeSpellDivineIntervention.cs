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
        SaveGame.Project(0, 1, SaveGame.Player.MapY, SaveGame.Player.MapX, 777, SaveGame.SingletonRepository.Projectiles.Get<HolyFireProjectile>(),
            ProjectionFlag.ProjectKill);
        SaveGame.DispelMonsters(SaveGame.Player.ExperienceLevel * 4);
        SaveGame.SlowMonsters();
        SaveGame.StunMonsters(SaveGame.Player.ExperienceLevel * 4);
        SaveGame.ConfuseMonsters(SaveGame.Player.ExperienceLevel * 4);
        SaveGame.TurnMonsters(SaveGame.Player.ExperienceLevel * 4);
        SaveGame.StasisMonsters(SaveGame.Player.ExperienceLevel * 4);
        SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Player.ExperienceLevel, new CthuloidMonsterSelector(), true);
        SaveGame.Player.TimedSuperheroism.AddTimer(Program.Rng.DieRoll(25) + 25);
        SaveGame.Player.RestoreHealth(300);
        if (SaveGame.Player.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(20 + SaveGame.Player.ExperienceLevel) + SaveGame.Player.ExperienceLevel);
        }
        else
        {
            SaveGame.Player.TimedHaste.AddTimer(Program.Rng.DieRoll(5));
        }
        SaveGame.Player.TimedFear.ResetTimer();
    }

    public override string Name => "Divine Intervention";
    
    protected override string? Info()
    {
        return $"h300/d{SaveGame.Player.ExperienceLevel * 4}+777";
    }
}