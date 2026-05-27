// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AdrenalineChannelingTalentScript : UniversalScript, IGetKey
{
    private AdrenalineChannelingTalentScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState) { }
    public override void ExecuteScript()
    {
        Game.FearTimer.ResetTimer();
        Game.StunTimer.ResetTimer();
        Game.RestoreHealth(Game.ExperienceLevel.IntValue);
        int duration = 10 + Game.DieRoll(Game.ExperienceLevel.IntValue * 3 / 2);
        if (Game.ExperienceLevel.IntValue < 35)
        {
            Game.HeroismTimer.AddTimer(duration);
        }
        else
        {
            Game.SuperheroismTimer.AddTimer(duration);
        }
        if (Game.HasteTimer.Value == 0)
        {
            Game.HasteTimer.SetTimer(duration);
        }
        else
        {
            Game.HasteTimer.AddTimer(duration);
        }
    }
}
