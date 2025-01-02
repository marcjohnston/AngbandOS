// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SleepGasScript : Script, IScript, ICastSpellScript
{
    private SleepGasScript(Game game) : base(game) { }

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
        // Paralyse the player
        Game.MsgPrint("A strange white mist surrounds you!");
        if (!Game.HasFreeAction)
        {
            Game.ParalysisTimer.AddTimer(Game.RandomLessThan(10) + 5);
        }
    }
}
