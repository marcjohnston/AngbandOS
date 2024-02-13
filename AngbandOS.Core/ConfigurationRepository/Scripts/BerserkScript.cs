// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BerserkScript : Script, IScript
{
    private BerserkScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Restores 30 points of health, removes fear and adds between 25 and 50 turns of super heroism.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.TimedSuperheroism.AddTimer(SaveGame.DieRoll(25) + 25);
        SaveGame.RestoreHealth(30);
        SaveGame.TimedFear.ResetTimer();
    }
}
