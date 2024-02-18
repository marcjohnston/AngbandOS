// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Runtime.CompilerServices;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WinnerScript : Script, IScript
{
    private WinnerScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.IsWinner = true;
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawTitleFlaggedAction)).Set();
        SaveGame.MsgPrint("*** CONGRATULATIONS ***");
        SaveGame.MsgPrint("You have won the game!");
        SaveGame.MsgPrint("You may retire ('Q') when you are ready.");
    }
}
