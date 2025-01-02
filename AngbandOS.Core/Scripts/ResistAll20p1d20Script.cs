// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResistAll20p1d20Script : Script, IActivateItemScript
{
    private ResistAll20p1d20Script(Game game) : base(game) { }

    public UsedResult ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        Game.AcidResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.LightningResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.FireResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.ColdResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.PoisonResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        return new UsedResult(true);
    }
}
