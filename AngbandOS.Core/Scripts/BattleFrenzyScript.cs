// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BattleFrenzyScript : Script, IScript
{
    private BattleFrenzyScript(Game game) : base(game) { }

    /// <summary>
    /// Restores 30 points of health, removes fear, adds between 25 and 50 turns of super heroism and adds up to 5 turns of haste if the player already has
    /// haste or between 1/2 experience and 1/2 experience + 20 turns of haste, if the player has none.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.SuperheroismTimer.AddTimer(Game.DieRoll(25) + 25);
        Game.RestoreHealth(30);
        Game.FearTimer.ResetTimer();
        if (Game.HasteTimer.Value == 0)
        {
            Game.HasteTimer.SetTimer(Game.DieRoll(20 + (Game.ExperienceLevel.Value / 2)) + (Game.ExperienceLevel.Value / 2));
        }
        else
        {
            Game.HasteTimer.AddTimer(Game.DieRoll(5));
        }
    }
}
