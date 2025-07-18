﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DimensionalGateScript : Script, IActivateItemScript
{
    private DimensionalGateScript(Game game) : base(game) { }

    public UsedResultEnum ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        if (!Game.TgtPt(out int ii, out int ij))
        {
            return UsedResultEnum.False;
        }
        Game.Energy -= 60 - Game.ExperienceLevel.IntValue;
        if (!Game.GridPassableNoCreature(ij, ii) ||
            Game.Map.Grid[ij][ii].InVault ||
            Game.Distance(ij, ii, Game.MapY.IntValue, Game.MapX.IntValue) > Game.ExperienceLevel.IntValue + 2 ||
            Game.RandomLessThan(Game.ExperienceLevel.IntValue * Game.ExperienceLevel.IntValue / 2) == 0)
        {
            Game.MsgPrint("You fail to exit the astral plane correctly!");
            Game.Energy -= 100;
            Game.RunScript(nameof(TeleportSelf10TeleportSelfScript));
        }
        else
        {
            Game.TeleportPlayerTo(ij, ii);
        }
        return UsedResultEnum.True;
    }
}
