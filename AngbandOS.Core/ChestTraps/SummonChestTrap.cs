﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ChestTraps;

[Serializable]
internal class SummonChestTrap : ChestTrap
{
    private SummonChestTrap(Game game) : base(game) { }
    public override bool Activate(int x, int y)
    {
        Game.RunScript(nameof(YouAreEnvelopedInACloudOfSmokeRenderMessageScript));
        int num = 2 + Game.DieRoll(3);
        for (int i = 0; i < num; i++)
        {
            if (Game.DieRoll(100) < Game.Difficulty)
            {
                Game.ActivateHiSummon();
            }
            else
            {
                Game.SummonSpecific(y, x, Game.Difficulty, null, true, false);
            }
        }
        return false;
    }

    public override string Description => "(Summoning Runes)";
}
