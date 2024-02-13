// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BattleFrenzyScript : Script, IScript
{
    private BattleFrenzyScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Restores 30 points of health, removes fear, adds between 25 and 50 turns of super heroism and adds up to 5 turns of haste if the player already has
    /// haste or between 1/2 experience and 1/2 experience + 20 turns of haste, if the player has none.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.TimedSuperheroism.AddTimer(SaveGame.DieRoll(25) + 25);
        SaveGame.RestoreHealth(30);
        SaveGame.TimedFear.ResetTimer();
        if (SaveGame.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.TimedHaste.SetTimer(SaveGame.DieRoll(20 + (SaveGame.ExperienceLevel / 2)) + (SaveGame.ExperienceLevel / 2));
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(SaveGame.DieRoll(5));
        }
    }
}
