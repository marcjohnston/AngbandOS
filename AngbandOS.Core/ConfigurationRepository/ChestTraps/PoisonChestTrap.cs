// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

[Serializable]
internal class PoisonChestTrap : ChestTrap
{
    private PoisonChestTrap(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        SaveGame.MsgPrint("A puff of green gas surrounds you!");
        if (!(SaveGame.HasPoisonResistance || SaveGame.TimedPoisonResistance.TurnsRemaining != 0))
        {
            if (SaveGame.DieRoll(10) <= SaveGame.SingletonRepository.Gods.Get(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else
            {
                SaveGame.TimedPoison.AddTimer(10 + SaveGame.DieRoll(20));
            }
        }
    }

    public override string Description => "(Gas Trap)";
}
