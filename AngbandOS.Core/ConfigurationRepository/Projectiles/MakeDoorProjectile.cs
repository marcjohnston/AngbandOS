﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class MakeDoorProjectile : Projectile
{
    private MakeDoorProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<BrightBrownSparkleAnimation>();

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        bool obvious = false;
        if (!SaveGame.GridOpenNoItemOrCreature(y, x))
        {
            return false;
        }
        SaveGame.CaveSetFeat(y, x, "LockedDoor0");
        if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorized))
        {
            obvious = true;
        }
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateMonstersFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateLightFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateViewFlaggedAction>().Set();
        return obvious;
    }

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        string? note = null;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return false;
    }
}