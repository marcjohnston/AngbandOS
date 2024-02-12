// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ClairvoyanceScript : Script, IScript
{
    private ClairvoyanceScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Adds between 30 and 55 turns of telepathy.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.RunScript(nameof(LightScript));
        if (!SaveGame.HasTelepathy)
        {
            SaveGame.TimedTelepathy.AddTimer(SaveGame.Rng.DieRoll(30) + 25);
        }
    }
}
