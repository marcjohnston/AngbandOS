﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ToggleSearchScript : Script, IScript, IRepeatableScript
{
    private ToggleSearchScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the toggle search script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the toggle search script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.IsSearching = !SaveGame.IsSearching;
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawSpeedFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStateFlaggedAction)).Set();
    }
}