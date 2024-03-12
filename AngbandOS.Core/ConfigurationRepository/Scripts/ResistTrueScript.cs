// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResistTrueScript : Script, IScript
{
    private ResistTrueScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Adds between 20 and 40 turns of resistance to acid, lightning, fire, cold and poison.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.AcidResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.LightningResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.FireResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.ColdResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.PoisonResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
    }
}
