﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Drain 100 health from an opponent, and give it to the player.
/// </summary>
[Serializable]
internal class Vampire2DirectionalActivation : DirectionalActivation
{
    private Vampire2DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => ""; // This command does not display a message.

    protected override string RechargeTimeRollExpression => "400";

    protected override bool Activate(int direction)
    {
        for (int i = 0; i < 3; i++)
        {
            if (Game.DrainLife(direction, 100))
            {
                Game.RestoreHealth(100);
            }
        }
        return true;
    }

    public override int Value => 2500;

    public override string Name => "Vampiric drain 3x (100)";

}
