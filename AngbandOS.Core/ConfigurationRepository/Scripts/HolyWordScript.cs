// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HolyWordScript : Script, IScript
{
    private HolyWordScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.RunScriptInt(nameof(DispelEvil4xScript), SaveGame.ExperienceLevel * 4);
        SaveGame.RestoreHealth(1000);
        SaveGame.TimedFear.ResetTimer();
        SaveGame.PoisonTimer.ResetTimer();
        SaveGame.TimedStun.ResetTimer();
        SaveGame.TimedBleeding.ResetTimer();
    }
}
