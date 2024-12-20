﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AlterRealityScript : Script, IScript, IRepeatableScript
{
    private AlterRealityScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Takes the player to a new level with a random starting location.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.MsgPrint("The world changes!");
        Game.DoCmdSaveGame(true);
        Game.NewLevelFlag = true;
        Game.CameFrom = LevelStartEnum.StartRandom;
    }
}
