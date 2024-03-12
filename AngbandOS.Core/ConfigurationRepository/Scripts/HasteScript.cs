// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HasteScript : Script, IScript
{
    private HasteScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Temporarily adds a random amount of haste from the experience level up to 2x the experience level + 20, if the player
    /// has no haste; or up to an additional 5 turns, if the player already has haste.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.HasteTimer.Value == 0)
        {
            SaveGame.HasteTimer.SetTimer(SaveGame.DieRoll(20 + SaveGame.ExperienceLevel) + SaveGame.ExperienceLevel);
        }
        else
        {
            SaveGame.HasteTimer.AddTimer(SaveGame.DieRoll(5));
        }
    }
}
