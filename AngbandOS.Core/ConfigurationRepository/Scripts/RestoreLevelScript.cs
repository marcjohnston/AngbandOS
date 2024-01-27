// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestoreLevelScript : Script, IScript, ISuccessfulScript
{
    private RestoreLevelScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Restores the players experience points and returns true, if the players experience was increased; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        if (SaveGame.ExperiencePoints < SaveGame.MaxExperienceGained)
        {
            SaveGame.MsgPrint("You feel your life energies returning.");
            SaveGame.ExperiencePoints = SaveGame.MaxExperienceGained;
            SaveGame.CheckExperience();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
