// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

[Serializable]
internal class SummonChestTrap : ChestTrap
{
    private SummonChestTrap(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        int num = 2 + SaveGame.DieRoll(3);
        SaveGame.MsgPrint("You are enveloped in a cloud of smoke!");
        for (int i = 0; i < num; i++)
        {
            if (SaveGame.DieRoll(100) < SaveGame.Difficulty)
            {
                SaveGame.ActivateHiSummon();
            }
            else
            {
                SaveGame.SummonSpecific(eventArgs.Y, eventArgs.X, SaveGame.Difficulty, null);
            }
        }
    }

    public override string Description => "(Summoning Runes)";
}
