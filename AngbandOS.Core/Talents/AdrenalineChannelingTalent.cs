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
    private AdrenalineChannelingTalent(Game game) : base(game) { }

    public override string Name => "Adrenaline Channeling";
    public override int Level => 23;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;

    public override void Use()
    {
        Game.FearTimer.ResetTimer();
        Game.StunTimer.ResetTimer();
        Game.RestoreHealth(Game.ExperienceLevel.IntValue);
        int i = 10 + Game.DieRoll(Game.ExperienceLevel.IntValue * 3 / 2);
        if (Game.ExperienceLevel.IntValue < 35)
        {
            Game.HeroismTimer.AddTimer(i);
        }
        else
        {
            Game.SuperheroismTimer.AddTimer(i);
        }
        if (Game.HasteTimer.Value == 0)
        {
            Game.HasteTimer.SetTimer(i);
        }
        else
        {
            Game.HasteTimer.AddTimer(i);
        }
    }

    protected override string LearnedDetails()
    {
        return $"dur 10+d{Game.ExperienceLevel.IntValue * 3 / 2}";
    }
}