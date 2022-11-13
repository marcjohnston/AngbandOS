// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Commands;
using AngbandOS.Core;
using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;
using AngbandOS.Spells;


namespace AngbandOS.Projection
{
    internal abstract class Projectile
    {
        protected readonly SaveGame SaveGame;
        protected int ProjectMn;
        protected int ProjectMx;
        protected int ProjectMy;

        public Projectile(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        protected abstract string BoltGraphic { get; }

        protected virtual string EffectAnimation { get; } = "";

        protected virtual string ImpactGraphic { get; } = "";

        /// <summary>
        /// Returns true, if the projectile actally hits and affects a monster.
        /// </summary>
        /// <param name="who"></param>
        /// <param name="rad"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="dam"></param>
        /// <param name="flg"></param>
        /// <returns></returns>
        public bool Fire(int who, int rad, int y, int x, int dam, ProjectionFlag flg)
        {
            int i, dist;
            int y1, x1;
            int msec = GlobalData.DelayFactor * GlobalData.DelayFactor * GlobalData.DelayFactor;
            GridTile cPtr;
            bool notice = false;
            bool visual = false;
            bool drawn = false;
            bool breath = false;
            bool blind = SaveGame.Player.TimedBlindness != 0;
            int grids = 0;
            int[] gx = new int[256];
            int[] gy = new int[256];
            int[] gm = new int[32];
            int gmRad = rad;
            ProjectileGraphic projectileEntity = string.IsNullOrEmpty(BoltGraphic) ? null : ObjectRepository.ProjectileGraphics[BoltGraphic];
            ProjectileGraphic impactEntity = string.IsNullOrEmpty(ImpactGraphic) ? null : ObjectRepository.ProjectileGraphics[ImpactGraphic];
            Animation animationEntity = string.IsNullOrEmpty(EffectAnimation) ? null : ObjectRepository.Animations[EffectAnimation];
            if ((flg & ProjectionFlag.ProjectJump) != 0)
            {
                x1 = x;
                y1 = y;
            }
            else if (who == 0)
            {
                x1 = SaveGame.Player.MapX;
                y1 = SaveGame.Player.MapY;
            }
            else
            {
                x1 = SaveGame.Level.Monsters[who].MapX;
                y1 = SaveGame.Level.Monsters[who].MapY;
            }
            int ySaver = y1;
            int xSaver = x1;
            int y2 = y;
            int x2 = x;
            if ((flg & ProjectionFlag.ProjectThru) != 0)
            {
                if (x1 == x2 && y1 == y2)
                {
                    flg &= ~ProjectionFlag.ProjectThru;
                }
            }
            if (rad < 0)
            {
                rad = 0 - rad;
                breath = true;
                flg |= ProjectionFlag.ProjectHide;
            }
            for (dist = 0; dist < 32; dist++)
            {
                gm[dist] = 0;
            }
            SaveGame.HandleStuff();
            x = x1;
            y = y1;
            dist = 0;
            while (true)
            {
                if ((flg & ProjectionFlag.ProjectBeam) != 0)
                {
                    gy[grids] = y;
                    gx[grids] = x;
                    grids++;
                }
                if (!blind && (flg & ProjectionFlag.ProjectHide) == 0 && dist != 0 &&
                    (flg & ProjectionFlag.ProjectBeam) != 0 && SaveGame.Level.PanelContains(y, x) &&
                    SaveGame.Level.PlayerHasLosBold(y, x))
                {
                    if (impactEntity != null)
                    {
                        SaveGame.Level.PrintCharacterAtMapLocation(impactEntity.Character, impactEntity.Colour, y, x);
                    }
                }
                cPtr = SaveGame.Level.Grid[y][x];
                if (dist != 0 && !SaveGame.Level.GridPassable(y, x))
                {
                    break;
                }
                if ((flg & ProjectionFlag.ProjectThru) == 0 && x == x2 && y == y2)
                {
                    break;
                }
                if (cPtr.MonsterIndex != 0 && dist != 0 && (flg & ProjectionFlag.ProjectStop) != 0)
                {
                    break;
                }
                SaveGame.Level.MoveOneStepTowards(out int y9, out int x9, y, x, y1, x1, y2, x2);
                if (!SaveGame.Level.GridPassable(y9, x9) && rad > 0)
                {
                    break;
                }
                dist++;
                if (dist > Constants.MaxRange)
                {
                    break;
                }
                if (!blind && (flg & ProjectionFlag.ProjectHide) == 0)
                {
                    if (SaveGame.Level.PlayerHasLosBold(y9, x9) && SaveGame.Level.PanelContains(y9, x9))
                    {
                        if (projectileEntity != null)
                        {
                            char directionalCharacter = projectileEntity.Character;
                            if (directionalCharacter == '|')
                            {
                                directionalCharacter = BoltChar(y, x, y9, x9);
                            }
                            SaveGame.Level.PrintCharacterAtMapLocation(directionalCharacter, projectileEntity.Colour, y9, x9);
                            SaveGame.Level.MoveCursorRelative(y9, x9);
                            SaveGame.UpdateScreen();
                            visual = true;
                            SaveGame.Pause(msec);
                            SaveGame.Level.RedrawSingleLocation(y9, x9);
                            SaveGame.UpdateScreen();
                        }
                    }
                    else if (visual)
                    {
                        SaveGame.Pause(msec);
                    }
                }
                y = y9;
                x = x9;
            }
            y2 = y;
            x2 = x;
            gm[0] = 0;
            gm[1] = grids;
            int distHack = dist;
            if (dist <= Constants.MaxRange)
            {
                if ((flg & ProjectionFlag.ProjectBeam) != 0 && grids > 0)
                {
                    grids--;
                }
                if (breath)
                {
                    int brad = 0;
                    int bdis = 0;
                    bool done = false;
                    flg &= ~ProjectionFlag.ProjectHide;
                    int by = y1;
                    int bx = x1;
                    while (bdis <= dist + rad)
                    {
                        for (int cdis = 0; cdis <= brad; cdis++)
                        {
                            for (y = by - cdis; y <= by + cdis; y++)
                            {
                                for (x = bx - cdis; x <= bx + cdis; x++)
                                {
                                    if (!SaveGame.Level.InBounds(y, x))
                                    {
                                        continue;
                                    }
                                    if (SaveGame.Level.Distance(y1, x1, y, x) != bdis)
                                    {
                                        continue;
                                    }
                                    if (SaveGame.Level.Distance(by, bx, y, x) != cdis)
                                    {
                                        continue;
                                    }
                                    if (!SaveGame.Level.Los(by, bx, y, x))
                                    {
                                        continue;
                                    }
                                    gy[grids] = y;
                                    gx[grids] = x;
                                    grids++;
                                }
                            }
                        }
                        gm[bdis + 1] = grids;
                        if (by == y2 && bx == x2)
                        {
                            done = true;
                        }
                        if (done)
                        {
                            bdis++;
                            continue;
                        }
                        SaveGame.Level.MoveOneStepTowards(out by, out bx, by, bx, y1, x1, y2, x2);
                        bdis++;
                        brad = rad * bdis / dist;
                    }
                    gmRad = bdis;
                }
                else
                {
                    for (dist = 0; dist <= rad; dist++)
                    {
                        for (y = y2 - dist; y <= y2 + dist; y++)
                        {
                            for (x = x2 - dist; x <= x2 + dist; x++)
                            {
                                if (!SaveGame.Level.InBounds2(y, x))
                                {
                                    continue;
                                }
                                if (SaveGame.Level.Distance(y2, x2, y, x) != dist)
                                {
                                    continue;
                                }
                                if (GetType().Name == "ProjectDisintegrate")
                                {
                                    if (SaveGame.Level.CaveValidBold(y, x))
                                    {
                                        SaveGame.Level.RevertTileToBackground(y, x);
                                    }
                                    SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent |
                                                      UpdateFlags.UpdateMonsters);
                                }
                                else
                                {
                                    if (!SaveGame.Level.Los(y2, x2, y, x))
                                    {
                                        continue;
                                    }
                                }
                                gy[grids] = y;
                                gx[grids] = x;
                                grids++;
                            }
                        }
                        gm[dist + 1] = grids;
                    }
                }
            }
            if (grids == 0)
            {
                return false;
            }
            if (!blind && (flg & ProjectionFlag.ProjectHide) == 0)
            {
                for (int t = 0; t <= gmRad; t++)
                {
                    for (i = gm[t]; i < gm[t + 1]; i++)
                    {
                        y = gy[i];
                        x = gx[i];
                        if (SaveGame.Level.PlayerHasLosBold(y, x) && SaveGame.Level.PanelContains(y, x))
                        {
                            if (impactEntity != null)
                            {
                                drawn = true;
                                SaveGame.Level.PrintCharacterAtMapLocation(impactEntity.Character, impactEntity.Colour, y, x);
                            }
                        }
                    }
                    if (impactEntity != null)
                    {
                        SaveGame.Level.MoveCursorRelative(y2, x2);
                        SaveGame.UpdateScreen();
                        if (visual || drawn)
                        {
                            SaveGame.Pause(msec);
                        }
                    }
                }
                if (drawn)
                {
                    for (i = 0; i < grids; i++)
                    {
                        y = gy[i];
                        x = gx[i];
                        if (SaveGame.Level.PlayerHasLosBold(y, x) && SaveGame.Level.PanelContains(y, x))
                        {
                            SaveGame.Level.RedrawSingleLocation(y, x);
                        }
                    }
                    SaveGame.Level.MoveCursorRelative(y2, x2);
                    SaveGame.UpdateScreen();
                }
            }

            if (animationEntity != null)
            {
                animationEntity.Animate(SaveGame, SaveGame.Level, gy, gx);
            }

            if ((flg & ProjectionFlag.ProjectGrid) != 0)
            {
                dist = 0;
                for (i = 0; i < grids; i++)
                {
                    if (gm[dist + 1] == i)
                    {
                        dist++;
                    }
                    y = gy[i];
                    x = gx[i];
                    if (AffectFloor(y, x))
                    {
                        notice = true;
                    }
                }
            }
            if ((flg & ProjectionFlag.ProjectItem) != 0)
            {
                dist = 0;
                for (i = 0; i < grids; i++)
                {
                    if (gm[dist + 1] == i)
                    {
                        dist++;
                    }
                    y = gy[i];
                    x = gx[i];
                    if (AffectItem(who, y, x))
                    {
                        notice = true;
                    }
                }
            }
            if ((flg & ProjectionFlag.ProjectKill) != 0)
            {
                ProjectMn = 0;
                ProjectMx = 0;
                ProjectMy = 0;
                dist = 0;
                for (i = 0; i < grids; i++)
                {
                    if (gm[dist + 1] == i)
                    {
                        dist++;
                    }
                    y = gy[i];
                    x = gx[i];
                    if (grids > 1)
                    {
                        if (AffectMonster(who, dist, y, x, dam))
                        {
                            notice = true;
                        }
                    }
                    else
                    {
                        if (cPtr.MonsterIndex == 0)
                        {
                            continue;
                        }
                        MonsterRace refPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex].Race;
                        if ((refPtr.Flags2 & MonsterFlag2.Reflecting) != 0 && Program.Rng.DieRoll(10) != 1 &&
                            distHack > 1 && GetType().Name != "ProjectWizardBolt")
                        {
                            int tY, tX;
                            int maxAttempts = 10;
                            do
                            {
                                tY = ySaver - 1 + Program.Rng.DieRoll(3);
                                tX = xSaver - 1 + Program.Rng.DieRoll(3);
                                maxAttempts--;
                            } while (maxAttempts > 0 && SaveGame.Level.InBounds2(tY, tX) && !SaveGame.Level.Los(y, x, tY, tX));
                            if (maxAttempts < 1)
                            {
                                tY = ySaver;
                                tX = xSaver;
                            }
                            if (SaveGame.Level.Monsters[cPtr.MonsterIndex].IsVisible)
                            {
                                SaveGame.MsgPrint("The attack bounces!");
                                refPtr.Knowledge.RFlags2 |= MonsterFlag2.Reflecting;
                            }
                            Fire(cPtr.MonsterIndex, 0, tY, tX, dam, flg);
                        }
                        else
                        {
                            if (AffectMonster(who, dist, y, x, dam))
                            {
                                notice = true;
                            }
                        }
                    }
                }
                if (who == 0 && ProjectMn == 1 && (flg & ProjectionFlag.ProjectJump) == 0)
                {
                    x = ProjectMx;
                    y = ProjectMy;
                    cPtr = SaveGame.Level.Grid[y][x];
                    if (cPtr.MonsterIndex != 0)
                    {
                        Monster mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
                        if (mPtr.IsVisible)
                        {
                            SaveGame.HealthTrack(cPtr.MonsterIndex);
                        }
                    }
                }
            }
            if ((flg & ProjectionFlag.ProjectKill) != 0)
            {
                dist = 0;
                for (i = 0; i < grids; i++)
                {
                    if (gm[dist + 1] == i)
                    {
                        dist++;
                    }
                    y = gy[i];
                    x = gx[i];

                    // Check to see if the projectile can affect the player.
                    if (x == SaveGame.Player.MapX && y == SaveGame.Player.MapY && who != 0)
                    {
                        // Check to see if the projectile attack bounces off the player.
                        if (!CheckBounceOffPlayer(who, dam, rad))
                        {
                            // Allow the projectile to perform any effects on the player.
                            if (AffectPlayer(who, dist, y, x, dam, rad))
                            {
                                // Disturb the player.
                                SaveGame.Disturb(true);
                                
                                // The effects were noticed.
                                notice = true;
                            }
                        }
                    }
                }
            }
            return notice;
        }

        protected virtual bool CheckBounceOffPlayer(int who, int dam, int aRad)
        {
            if (SaveGame.Player.HasReflection && aRad == 0 && Program.Rng.DieRoll(10) != 1)
            {
                bool blind = SaveGame.Player.TimedBlindness != 0;
                SaveGame.MsgPrint(blind ? "Something bounces!" : "The attack bounces!");

                int tY;
                int tX;
                int maxAttempts = 10;
                do
                {
                    tY = SaveGame.Level.Monsters[who].MapY - 1 + Program.Rng.DieRoll(3);
                    tX = SaveGame.Level.Monsters[who].MapX - 1 + Program.Rng.DieRoll(3);
                    maxAttempts--;
                } while (maxAttempts > 0 && SaveGame.Level.InBounds2(tY, tX) && !SaveGame.Level.PlayerHasLosBold(tY, tX));
                if (maxAttempts < 1)
                {
                    tY = SaveGame.Level.Monsters[who].MapY;
                    tX = SaveGame.Level.Monsters[who].MapX;
                }
                Fire(0, 0, tY, tX, dam, ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill);
                SaveGame.Disturb(true);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Perform any effect needed on the floor and returns true, if the effect was noticed.  Does nothing and returns false, by default.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        protected virtual bool AffectFloor(int y, int x) => false;

        /// <summary>
        /// Perform any effect needed on the item and returns true, if the effect was noticed.  Does nothing and return false, by default.
        /// </summary>
        /// <param name="who"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        protected virtual bool AffectItem(int who, int y, int x) => false;

        protected abstract bool AffectMonster(int who, int r, int y, int x, int dam);

        /// <summary>
        /// Perform any effect needed on the player and returns true, if the effect was noticed.  Disturbs the player and returns true, by default.
        /// </summary>
        /// <param name="who"></param>
        /// <param name="r"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="dam"></param>
        /// <param name="aRad"></param>
        /// <returns></returns>
        protected virtual bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            return true;
        }

        private char BoltChar(int y, int x, int ny, int nx)
        {
            if (ny == y && nx == x)
            {
                return '*';
            }
            if (ny == y)
            {
                return '-';
            }
            if (nx == x)
            {
                return '|';
            }
            if (ny - y == x - nx)
            {
                return '/';
            }
            if (ny - y == nx - x)
            {
                return '\\';
            }
            return '*';
        }
    }
}