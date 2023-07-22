// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class AdrenalineChannelingTalent : Talent
{
    private AdrenalineChannelingTalent(SaveGame saveGame) : base(saveGame) { }

    public override string Name => "Adrenaline Channeling";
    public override void Initialize(int characterClass)
    {
        Level = 23;
        ManaCost = 15;
        BaseFailure = 50;
    }

    public override void Use()
    {
        SaveGame.Player.TimedFear.ResetTimer();
        SaveGame.Player.TimedStun.ResetTimer();
        SaveGame.Player.RestoreHealth(SaveGame.Player.ExperienceLevel);
        int i = 10 + Program.Rng.DieRoll(SaveGame.Player.ExperienceLevel * 3 / 2);
        if (SaveGame.Player.ExperienceLevel < 35)
        {
            SaveGame.Player.TimedHeroism.AddTimer(i);
        }
        else
        {
            SaveGame.Player.TimedSuperheroism.AddTimer(i);
        }
        if (SaveGame.Player.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.Player.TimedHaste.SetTimer(i);
        }
        else
        {
            SaveGame.Player.TimedHaste.AddTimer(i);
        }
    }

    protected override string Comment()
    {
        return $"dur 10+d{SaveGame.Player.ExperienceLevel * 3 / 2}";
    }
}