// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResistanceScript : Script, IEatOrQuaffScript
{
    private ResistanceScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        // Resistance gives you all timed resistances
        Game.AcidResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.LightningResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.RunScript(nameof(Add1d20p20FireResistanceTimer));
        Game.ColdResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.PoisonResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        return new IdentifiedResult(true);
    }
}