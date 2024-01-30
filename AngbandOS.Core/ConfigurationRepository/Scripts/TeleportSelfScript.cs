// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TeleportSelfScript : Script, IScriptInt
{
    private TeleportSelfScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Teleports the player between a specified distance from 1/2 of the distance up to a maximum of 200.
    /// </summary>
    /// <param name="distance">A distance up to 200.</param>
    /// <returns></returns>
    public void ExecuteScriptInt(int distance)
    {
        int x = SaveGame.MapX;
        int y = SaveGame.MapY;
        int xx = -1;
        bool look = true;
        if (SaveGame.HasAntiTeleport)
        {
            SaveGame.MsgPrint("A mysterious force prevents you from teleporting!");
            return;
        }
        if (distance > 200)
        {
            distance = 200;
        }
        int min = distance / 2;
        while (look)
        {
            if (distance > 200)
            {
                distance = 200;
            }
            for (int i = 0; i < 500; i++)
            {
                while (true)
                {
                    x = SaveGame.Rng.RandomSpread(SaveGame.MapX, distance);
                    y = SaveGame.Rng.RandomSpread(SaveGame.MapY, distance);
                    int d = SaveGame.Distance(SaveGame.MapY, SaveGame.MapX, y, x);
                    if (d >= min && d <= distance)
                    {
                        break;
                    }
                }
                if (!SaveGame.InBounds(y, x))
                {
                    continue;
                }
                if (!SaveGame.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                if (SaveGame.Grid[y][x].TileFlags.IsSet(GridTile.InVault))
                {
                    continue;
                }
                look = false;
                break;
            }
            distance *= 2;
            min /= 2;
        }
        SaveGame.PlaySound(SoundEffectEnum.Teleport);
        int oy = SaveGame.MapY;
        int ox = SaveGame.MapX;
        SaveGame.MapY = y;
        SaveGame.MapX = x;
        SaveGame.RedrawSingleLocation(oy, ox);
        while (xx < 2)
        {
            int yy = -1;
            while (yy < 2)
            {
                if (xx == 0 && yy == 0)
                {
                }
                else
                {
                    if (SaveGame.Grid[oy + yy][ox + xx].MonsterIndex != 0)
                    {
                        if (SaveGame.Monsters[SaveGame.Grid[oy + yy][ox + xx].MonsterIndex].Race.TeleportSelf &&
                            !SaveGame.Monsters[SaveGame.Grid[oy + yy][ox + xx].MonsterIndex].Race.ResistTeleport)
                        {
                            if (SaveGame.Monsters[SaveGame.Grid[oy + yy][ox + xx].MonsterIndex].SleepLevel == 0)
                            {
                                TeleportToPlayer(SaveGame.Grid[oy + yy][ox + xx].MonsterIndex);
                            }
                        }
                    }
                }
                yy++;
            }
            xx++;
        }
        SaveGame.RedrawSingleLocation(SaveGame.MapY, SaveGame.MapX);
        SaveGame.RecenterScreenAroundPlayer();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateScentFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateDistancesFlaggedAction)).Set();
        SaveGame.HandleStuff();
    }

    private void TeleportToPlayer(int mIdx)
    {
        int ny = SaveGame.MapY;
        int nx = SaveGame.MapX;
        int dis = 2;
        bool look = true;
        Monster mPtr = SaveGame.Monsters[mIdx];
        int attempts = 500;
        if (mPtr.Race == null)
        {
            return;
        }
        if (SaveGame.Rng.DieRoll(100) > mPtr.Race.Level)
        {
            return;
        }
        int oy = mPtr.MapY;
        int ox = mPtr.MapX;
        int min = dis / 2;
        while (look && --attempts != 0)
        {
            if (dis > 200)
            {
                dis = 200;
            }
            for (int i = 0; i < 500; i++)
            {
                while (true)
                {
                    ny = SaveGame.Rng.RandomSpread(SaveGame.MapY, dis);
                    nx = SaveGame.Rng.RandomSpread(SaveGame.MapX, dis);
                    int d = SaveGame.Distance(SaveGame.MapY, SaveGame.MapX, ny, nx);
                    if (d >= min && d <= dis)
                    {
                        break;
                    }
                }
                if (!SaveGame.InBounds(ny, nx))
                {
                    continue;
                }
                if (!SaveGame.GridPassableNoCreature(ny, nx))
                {
                    continue;
                }
                if (SaveGame.Grid[ny][nx].FeatureType.Name == "ElderSign")
                {
                    continue;
                }
                if (SaveGame.Grid[ny][nx].FeatureType.Name == "YellowSign")
                {
                    continue;
                }
                look = false;
                break;
            }
            dis *= 2;
            min /= 2;
        }
        if (attempts < 1)
        {
            return;
        }
        SaveGame.PlaySound(SoundEffectEnum.Teleport);
        SaveGame.Grid[ny][nx].MonsterIndex = mIdx;
        SaveGame.Grid[oy][ox].MonsterIndex = 0;
        mPtr.MapY = ny;
        mPtr.MapX = nx;
        SaveGame.UpdateMonsterVisibility(mIdx, true);
        SaveGame.RedrawSingleLocation(oy, ox);
        SaveGame.RedrawSingleLocation(ny, nx);
    }
}
