﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class KillWallProjectile : Projectile
{
    private KillWallProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<BrownSwirlAnimation>();

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        bool obvious = false;
        if (SaveGame.GridPassable(y, x))
        {
            return false;
        }
        if (cPtr.FeatureType.IsPermanent)
        {
            return false;
        }
        if (cPtr.FeatureType.Name.Contains("Treas"))
        {
            if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorized))
            {
                SaveGame.MsgPrint("The vein turns into mud!");
                SaveGame.MsgPrint("You have found something!");
                obvious = true;
            }
            cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
            SaveGame.RevertTileToBackground(y, x);
            SaveGame.PlaceGold(y, x);
        }
        else if (cPtr.FeatureType.Name.Contains("Magma") || cPtr.FeatureType.Name.Contains("Quartz"))
        {
            if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorized))
            {
                SaveGame.MsgPrint("The vein turns into mud!");
                obvious = true;
            }
            cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
            SaveGame.RevertTileToBackground(y, x);
        }
        else if (cPtr.FeatureType.IsWall)
        {
            if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorized))
            {
                SaveGame.MsgPrint("The wall turns into mud!");
                obvious = true;
            }
            cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
            SaveGame.RevertTileToBackground(y, x);
        }
        else if (cPtr.FeatureType.Name == "Rubble")
        {
            if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorized))
            {
                SaveGame.MsgPrint("The rubble turns into mud!");
                obvious = true;
            }
            cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
            SaveGame.RevertTileToBackground(y, x);
            if (SaveGame.Rng.RandomLessThan(100) < 10)
            {
                if (SaveGame.PlayerCanSeeBold(y, x))
                {
                    SaveGame.MsgPrint("There was something buried in the rubble!");
                    obvious = true;
                }
                SaveGame.PlaceObject(y, x, false, false);
            }
        }
        else
        {
            if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorized))
            {
                SaveGame.MsgPrint("The door turns into mud!");
                obvious = true;
            }
            cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
            SaveGame.RevertTileToBackground(y, x);
        }
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateScentFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateMonstersFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateLightFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateViewFlaggedAction>().Set();
        return obvious;
    }

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only friends that are hurt by rock are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.HurtByRock;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        string? noteDies = null;
        if (rPtr.HurtByRock)
        {
            if (seen)
            {
                obvious = true;
            }
            if (seen)
            {
                rPtr.Knowledge.Characteristics.HurtByRock = true;
            }
            note = " loses some skin!";
            noteDies = " dissolves!";
        }
        else
        {
            dam = 0;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
        return obvious;
    }
}