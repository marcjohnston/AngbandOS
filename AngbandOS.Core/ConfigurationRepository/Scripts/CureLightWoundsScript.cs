// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureLightWoundsScript : Script, IScript
{
    private CureLightWoundsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Restores health between 2 and 10 points and reduces the bleeding timer by 10 turns.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.RestoreHealth(SaveGame.Rng.DiceRoll(2, 10));
        SaveGame.TimedBleeding.AddTimer(-10);
    }
}
