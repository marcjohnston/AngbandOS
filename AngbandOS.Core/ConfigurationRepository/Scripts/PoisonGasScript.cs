// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PoisonGasScript : Script, IScript
{
    private PoisonGasScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Poison the player
        SaveGame.MsgPrint("A pungent green gas surrounds you!");
        if (!SaveGame.HasPoisonResistance && SaveGame.TimedPoisonResistance.Value == 0)
        {
            // Hagarg Ryonis may save you from the poison
            if (SaveGame.DieRoll(10) <= SaveGame.SingletonRepository.Gods.Get(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else
            {
                SaveGame.PoisonTimer.AddTimer(SaveGame.RandomLessThan(20) + 10);
            }
        }
    }
}
