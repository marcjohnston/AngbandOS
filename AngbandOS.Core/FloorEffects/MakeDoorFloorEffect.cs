﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FloorEffects;

[Serializable]
internal class MakeDoorFloorEffect : FloorEffect
{
    private MakeDoorFloorEffect(Game game) : base(game) { } // This object is a singleton.

    public override bool Apply(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        if (!Game.GridOpenNoItemOrCreature(y, x))
        {
            return false;
        }
        Game.CaveSetFeat(y, x, Game.SingletonRepository.Get<Tile>(nameof(LockedDoor0Tile)));
        if (cPtr.PlayerMemorized)
        {
            obvious = true;
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        return obvious;
    }
}
