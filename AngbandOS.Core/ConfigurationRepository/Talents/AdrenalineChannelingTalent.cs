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
    public override int Level => 23;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;

    public override void Use()
    {
        SaveGame.FearTimer.ResetTimer();
        SaveGame.StunTimer.ResetTimer();
        SaveGame.RestoreHealth(SaveGame.ExperienceLevel);
        int i = 10 + SaveGame.DieRoll(SaveGame.ExperienceLevel * 3 / 2);
        if (SaveGame.ExperienceLevel < 35)
        {
            SaveGame.HeroismTimer.AddTimer(i);
        }
        else
        {
            SaveGame.SuperheroismTimer.AddTimer(i);
        }
        if (SaveGame.HasteTimer.Value == 0)
        {
            SaveGame.HasteTimer.SetTimer(i);
        }
        else
        {
            SaveGame.HasteTimer.AddTimer(i);
        }
    }

    protected override string Comment()
    {
        return $"dur 10+d{SaveGame.ExperienceLevel * 3 / 2}";
    }
}