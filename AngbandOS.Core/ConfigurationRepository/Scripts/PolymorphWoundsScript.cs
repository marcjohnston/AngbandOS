﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PolymorphWoundsScript : Script
{
    private PolymorphWoundsScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        int wounds = SaveGame.TimedBleeding.TurnsRemaining;
        int hitP = SaveGame.MaxHealth - SaveGame.Health;
        int change = SaveGame.Rng.DiceRoll(SaveGame.ExperienceLevel, 5);
        bool nastyEffect = SaveGame.Rng.DieRoll(5) == 1;
        if (!(wounds != 0 || hitP != 0 || nastyEffect))
        {
            return false;
        }
        if (nastyEffect)
        {
            SaveGame.MsgPrint("A new wound was created!");
            SaveGame.TakeHit(change, "a polymorphed wound");
            SaveGame.TimedBleeding.SetTimer(change);
        }
        else
        {
            SaveGame.MsgPrint("Your wounds are polymorphed into less serious ones.");
            SaveGame.RestoreHealth(change);
            SaveGame.TimedBleeding.SetTimer(SaveGame.TimedBleeding.TurnsRemaining - (change / 2));
        }
        return false;
    }
}