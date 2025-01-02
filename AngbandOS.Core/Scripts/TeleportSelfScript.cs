// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TeleportSelfScript : Script, IScript, IScriptInt, IReadScrollAndUseStaffScript, IUsedScriptItem
{
    private TeleportSelfScript(Game game) : base(game) { }

    /// <summary>
    /// Teleports the player between a specified distance from 1/2 of the distance up to a maximum of 200.
    /// </summary>
    /// <param name="distance">A distance up to 200.</param>
    /// <returns></returns>
    public void ExecuteScriptInt(int distance)
    {
        int x = Game.MapX.IntValue;
        int y = Game.MapY.IntValue;
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
                    x = Game.RandomSpread(Game.MapX.IntValue, distance);
                    y = Game.RandomSpread(Game.MapY.IntValue, distance);
                    int d = Game.Distance(Game.MapY.IntValue, Game.MapX.IntValue, y, x);
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
                if (Game.Map.Grid[y][x].InVault)
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
        int oy = Game.MapY.IntValue;
        int ox = Game.MapX.IntValue;
        Game.MapY.IntValue = y;
        Game.MapX.IntValue = x;
        Game.MainForm.RefreshMapLocation(oy, ox);
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
                    if (Game.Map.Grid[oy + yy][ox + xx].MonsterIndex != 0)
                    {
                        if (Game.Monsters[Game.Map.Grid[oy + yy][ox + xx].MonsterIndex].Race.TeleportSelf && !Game.Monsters[Game.Map.Grid[oy + yy][ox + xx].MonsterIndex].Race.ResistTeleport)
                        {
                            if (Game.Monsters[Game.Map.Grid[oy + yy][ox + xx].MonsterIndex].SleepLevel == 0)
                            {
                                TeleportToPlayer(Game.Map.Grid[oy + yy][ox + xx].MonsterIndex);
                            }
                        }
                    }
                }
                yy++;
            }
            xx++;
        }
        Game.MainForm.RefreshMapLocation(Game.MapY.IntValue, Game.MapX.IntValue);
        Game.RecenterScreenAroundPlayer();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Set();
        Game.HandleStuff();
    }

    public void ExecuteScript()
    {
        ExecuteScriptInt(100);
    }

    private void TeleportToPlayer(int mIdx)
    {
        int ny = Game.MapY.IntValue;
        int nx = Game.MapX.IntValue;
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
                    ny = Game.RandomSpread(Game.MapY.IntValue, dis);
                    nx = Game.RandomSpread(Game.MapX.IntValue, dis);
                    int d = Game.Distance(Game.MapY.IntValue, Game.MapX.IntValue, ny, nx);
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
                if (Game.Map.Grid[ny][nx].FeatureType is ElderSignSigilTile)
                {
                    continue;
                }
                if (Game.Map.Grid[ny][nx].FeatureType is YellowSignSigilTile)
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
        Game.Map.Grid[ny][nx].MonsterIndex = mIdx;
        Game.Map.Grid[oy][ox].MonsterIndex = 0;
        mPtr.MapY = ny;
        mPtr.MapX = nx;
        Game.UpdateMonsterVisibility(mIdx, true);
        Game.MainForm.RefreshMapLocation(oy, ox);
        Game.MainForm.RefreshMapLocation(ny, nx);
    }

    public IdentifiedAndUsedResult ExecuteReadScrollAndUseStaffScript()
    {
        ExecuteScriptInt(100);
        return new IdentifiedAndUsedResult(true, true);
    }

    public bool ExecuteUsedScriptItem(Item item)
    {
        ExecuteScriptInt(100);
        return true;
    }
}
