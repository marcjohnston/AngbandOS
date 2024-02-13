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
        SaveGame.TimedAcidResistance.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.TimedLightningResistance.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.TimedFireResistance.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.TimedColdResistance.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.TimedPoisonResistance.AddTimer(SaveGame.DieRoll(20) + 20);
    }
}
