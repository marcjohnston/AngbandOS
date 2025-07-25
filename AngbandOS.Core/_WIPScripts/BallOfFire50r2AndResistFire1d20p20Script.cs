﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BallOfFire50r2AndResistFire1d20p20Script : Script, IActivateItemScript
{
    private BallOfFire50r2AndResistFire1d20p20Script(Game game) : base(game) { }

    public UsedResultEnum ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        Game.RunScript(nameof(Fire50r2ProjectileScript));
        Game.RunScript(nameof(FireResistance1d20p20TimerScript));
        return UsedResultEnum.True;
    }
}
