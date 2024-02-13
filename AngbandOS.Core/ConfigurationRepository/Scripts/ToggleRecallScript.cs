// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ToggleRecallScript : Script, IScript
{
    private ToggleRecallScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.WordOfRecallDelay == 0)
        {
            SaveGame.WordOfRecallDelay = SaveGame.DieRoll(20) + 15;
            SaveGame.MsgPrint("The air about you becomes charged...");
        }
        else
        {
            SaveGame.WordOfRecallDelay = 0;
            SaveGame.MsgPrint("A tension leaves the air around you...");
        }
    }
}
