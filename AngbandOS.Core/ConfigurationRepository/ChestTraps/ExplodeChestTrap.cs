﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

[Serializable]
internal class ExplodeChestTrap : ChestTrap
{
    private ExplodeChestTrap(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        SaveGame.MsgPrint("There is a sudden explosion!");
        SaveGame.TakeHit(SaveGame.Rng.DiceRoll(5, 8), "an exploding chest");
        eventArgs.DestroysContents = true;
    }

    public override string Description => "(Explosion Device)";
}