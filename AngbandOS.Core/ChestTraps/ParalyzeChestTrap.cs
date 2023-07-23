// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

[Serializable]
internal class ParalyzeChestTrap : ChestTrap
{
    private ParalyzeChestTrap(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        SaveGame.MsgPrint("A puff of yellow gas surrounds you!");
        if (!SaveGame.HasFreeAction)
        {
            SaveGame.TimedParalysis.AddTimer(10 + Program.Rng.DieRoll(20));
        }
    }

    public override string Description => "(Gas Trap)";
}
