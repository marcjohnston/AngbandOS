// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

internal class PoisonChestTrap : BaseChestTrap
{
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        eventArgs.SaveGame.MsgPrint("A puff of green gas surrounds you!");
        if (!(eventArgs.SaveGame.HasPoisonResistance || eventArgs.SaveGame.TimedPoisonResistance.TurnsRemaining != 0))
        {
            if (Program.Rng.DieRoll(10) <= eventArgs.SaveGame.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                eventArgs.SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else
            {
                eventArgs.SaveGame.TimedPoison.AddTimer(10 + Program.Rng.DieRoll(20));
            }
        }
    }

    public override string Description => "(Gas Trap)";
}
