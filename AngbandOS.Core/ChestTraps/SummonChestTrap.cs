// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

internal class SummonChestTrap : BaseChestTrap
{
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        int num = 2 + Program.Rng.DieRoll(3);
        eventArgs.SaveGame.MsgPrint("You are enveloped in a cloud of smoke!");
        for (int i = 0; i < num; i++)
        {
            if (Program.Rng.DieRoll(100) < eventArgs.SaveGame.Difficulty)
            {
                eventArgs.SaveGame.ActivateHiSummon();
            }
            else
            {
                eventArgs.SaveGame.Level.SummonSpecific(eventArgs.Y, eventArgs.X, eventArgs.SaveGame.Difficulty, null);
            }
        }
    }

    public override string Description => "(Summoning Runes)";
}
