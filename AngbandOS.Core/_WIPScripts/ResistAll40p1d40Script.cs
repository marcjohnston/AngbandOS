﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResistAll40p1d40Script : Script, IActivateItemScript
{
    private ResistAll40p1d40Script(Game game) : base(game) { }

    public UsedResultEnum ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        Game.RunScript(nameof(AcidResistance1d40p40TimerScript));
        Game.LightningResistanceTimer.AddTimer(Game.DieRoll(40) + 40);
        Game.RunScript(nameof(FireResistance1d40p40TimerScript));
        Game.ColdResistanceTimer.AddTimer(Game.DieRoll(40) + 40);
        Game.PoisonResistanceTimer.AddTimer(Game.DieRoll(40) + 40);
        return UsedResultEnum.True;
    }
}
