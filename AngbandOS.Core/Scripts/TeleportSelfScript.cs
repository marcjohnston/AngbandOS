// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TeleportSelfScript : Script, IScript, IScriptInt
{
    private TeleportSelfScript(Game game) : base(game) { }

    /// <summary>
    /// Teleports the player between a specified distance from 1/2 of the distance up to a maximum of 200.
    /// </summary>
    /// <param name="distance">A distance up to 200.</param>
    /// <returns></returns>
    public void ExecuteScriptInt(int distance)
    {
        int x = Game.MapX;
        int y = Game.MapY;
        int xx = -1;
        bool look = true;
        if (Game.HasAntiTeleport)
        {
            Game.MsgPrint("A mysterious force prevents you from teleporting!");
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
                    x = Game.RandomSpread(Game.MapX, distance);
                    y = Game.RandomSpread(Game.MapY, distance);
                    int d = Game.Distance(Game.MapY, Game.MapX, y, x);
                    if (d >= min && d <= distance)
                    {
                        break;
                    }
                }
                if (!Game.InBounds(y, x))
                {
                    continue;
                }
                if (!Game.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                if (Game.Grid[y][x].TileFlags.IsSet(GridTile.InVault))
                {
                    continue;
                }
                look = false;
                break;
            }
            distance *= 2;
            min /= 2;
        }
        Game.PlaySound(SoundEffectEnum.Teleport);
        int oy = Game.MapY;
        int ox = Game.MapX;
        Game.MapY = y;
        Game.MapX = x;
        Game.RedrawSingleLocation(oy, ox);
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
                    if (Game.Grid[oy + yy][ox + xx].MonsterIndex != 0)
                    {
                        if (Game.Monsters[Game.Grid[oy + yy][ox + xx].MonsterIndex].Race.TeleportSelf &&
                            !Game.Monsters[Game.Grid[oy + yy][ox + xx].MonsterIndex].Race.ResistTeleport)
                        {
                            if (Game.Monsters[Game.Grid[oy + yy][ox + xx].MonsterIndex].SleepLevel == 0)
                            {
                                TeleportToPlayer(Game.Grid[oy + yy][ox + xx].MonsterIndex);
                            }
                        }
                    }
                }
                yy++;
            }
            xx++;
        }
        Game.RedrawSingleLocation(Game.MapY, Game.MapX);
        Game.RecenterScreenAroundPlayer();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateScentFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateDistancesFlaggedAction)).Set();
        Game.HandleStuff();
    }

    public void ExecuteScript()
    {
        ExecuteScriptInt(100);
    }

    private void TeleportToPlayer(int mIdx)
    {
        int ny = Game.MapY;
        int nx = Game.MapX;
        int dis = 2;
        bool look = true;
        Monster mPtr = Game.Monsters[mIdx];
        int attempts = 500;
        if (mPtr.Race == null)
        {
            return;
        }
        if (Game.DieRoll(100) > mPtr.Race.Level)
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
                    ny = Game.RandomSpread(Game.MapY, dis);
                    nx = Game.RandomSpread(Game.MapX, dis);
                    int d = Game.Distance(Game.MapY, Game.MapX, ny, nx);
                    if (d >= min && d <= dis)
                    {
                        break;
                    }
                }
                if (!Game.InBounds(ny, nx))
                {
                    continue;
                }
                if (!Game.GridPassableNoCreature(ny, nx))
                {
                    continue;
                }
                if (Game.Grid[ny][nx].FeatureType is ElderSignSigilTile)
                {
                    continue;
                }
                if (Game.Grid[ny][nx].FeatureType is YellowSignSigilTile)
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
        Game.PlaySound(SoundEffectEnum.Teleport);
        Game.Grid[ny][nx].MonsterIndex = mIdx;
        Game.Grid[oy][ox].MonsterIndex = 0;
        mPtr.MapY = ny;
        mPtr.MapX = nx;
        Game.UpdateMonsterVisibility(mIdx, true);
        Game.RedrawSingleLocation(oy, ox);
        Game.RedrawSingleLocation(ny, nx);
    }
}
