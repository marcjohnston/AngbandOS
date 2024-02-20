// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class StoneSkinScript : Script, IScript
{
    private StoneSkinScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Adds between 30 and 50 turns of stoneskin.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.TimedStoneskin.AddTimer(SaveGame.DieRoll(20) + 30);
    }
}
