// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration11 : ChestTrapConfiguration
{
    private ChestTrapConfiguration11(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override ChestTrap[] Traps => new ChestTrap[] { SaveGame.SingletonRepository.ChestTraps.Get(nameof(LoseConChestTrap)) };
}