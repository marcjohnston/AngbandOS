﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class Projectile : IGetKey, IToJson
{
    protected readonly Game Game;

    public Projectile(Game game, ProjectileGameConfiguration projectileGameConfiguration)
    {
        Game = game;
        Key = projectileGameConfiguration.Key ?? projectileGameConfiguration.GetType().Name;
        FloorEffectBindingKey = projectileGameConfiguration.FloorEffectBindingKey;
        ItemEffectBindingKey = projectileGameConfiguration.ItemEffectBindingKey;
        PlayerEffectBindingKey = projectileGameConfiguration.PlayerEffectBindingKey;
        MonsterEffectBindingKey = projectileGameConfiguration.MonsterEffectBindingKey;
        BoltProjectileGraphicBindingKey = projectileGameConfiguration.BoltProjectileGraphicBindingKey;
        EffectAnimationBindingKey = projectileGameConfiguration.EffectAnimationBindingKey;
        ImpactProjectileGraphicBindingKey = projectileGameConfiguration.ImpactProjectileGraphicBindingKey;
    }


    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ProjectileGameConfiguration projectileDefinition = new ProjectileGameConfiguration()
        {
            Key = Key,
            FloorEffectBindingKey = FloorEffectBindingKey,
            MonsterEffectBindingKey = MonsterEffectBindingKey,
            ItemEffectBindingKey = ItemEffectBindingKey,
            PlayerEffectBindingKey = PlayerEffectBindingKey,
            ImpactProjectileGraphicBindingKey = ImpactProjectileGraphicBindingKey,
            EffectAnimationBindingKey = EffectAnimationBindingKey,
            BoltProjectileGraphicBindingKey = BoltProjectileGraphicBindingKey
        };
        return JsonSerializer.Serialize(projectileDefinition, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public void Bind()
    {
        MonsterEffect = Game.SingletonRepository.Get<MonsterEffect>(MonsterEffectBindingKey);
        ItemEffect = Game.SingletonRepository.Get<ItemEffect>(ItemEffectBindingKey);
        PlayerEffect = Game.SingletonRepository.Get<PlayerEffectUniversalScript>(PlayerEffectBindingKey);
        FloorEffect = Game.SingletonRepository.Get<FloorEffect>(FloorEffectBindingKey);
        ImpactProjectileGraphic = Game.SingletonRepository.GetNullable<ProjectileGraphic>(ImpactProjectileGraphicBindingKey);
        EffectAnimation = Game.SingletonRepository.GetNullable<Animation>(EffectAnimationBindingKey);
        BoltProjectileGraphic = Game.SingletonRepository.GetNullable<ProjectileGraphic>(BoltProjectileGraphicBindingKey);
    }

    /// <summary>
    /// Returns the graphics to be used while the projectile is in motion; or null, if there is no graphic.  Returns null, by default.
    /// </summary>
    protected ProjectileGraphic? BoltProjectileGraphic { get; private set; }

    protected virtual string? BoltProjectileGraphicBindingKey { get; } = null;

    protected Animation? EffectAnimation { get; private set; }

    protected virtual string? EffectAnimationBindingKey { get; } = null;

    /// <summary>
    /// Returns the graphics to be used when the projectile impacts something; or null, if there is no graphic.  Returns null, by default.
    /// </summary>
    protected ProjectileGraphic? ImpactProjectileGraphic { get; private set; }

    protected virtual string? ImpactProjectileGraphicBindingKey { get; } = null;

    /// <summary>
    /// Returns true, if the projectile actually hits and affects a monster.
    /// </summary>
    /// <param name="projectile"></param>
    /// <param name="dir"></param>
    /// <param name="dam"></param>
    /// <param name="flg"></param>
    /// <returns></returns>
    public bool TargetedFire(int dir, int dam, int rad, bool jump, bool beam, bool stop, bool kill, bool grid, bool item, bool thru, bool hide)
    {
        int tx = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
        int ty = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
        if (dir == 5 && Game.TargetWho != null)
        {
            GridCoordinate? target = Game.TargetWho.GetTargetLocation();
            if (target != null)
            {
                if (rad != 0)
                {
                    stop = false; // TODO: This means we can target a monster around a corner?
                }
                tx = target.X;
                ty = target.Y;
            }
        }
        return Fire(0, rad, ty, tx, dam, jump: jump, beam: beam, thru: thru, stop: stop, kill: kill, grid: grid, item: item, hide: hide);
    }

    /// <summary>
    /// Returns true, if the projectile actally hits and affects a monster.
    /// </summary>
    /// <param name="who"></param>
    /// <param name="rad"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <param name="dam"></param>
    /// <param name="jump">Allows the projectile or spell to skip directly to the target location, ignoring any intermediate grids or obstacles.</param>
    /// <param name="beam">Causes the effect to travel in a line, potentially hitting multiple targets along a straight path. Useful in corridors or for reaching enemies aligned with the caster.</param>
    /// <param name="thru">Lets the effect pass through targets or objects without stopping, continuing on to hit entities or objects further along its trajectory.</param>
    /// <param name="hide">Makes the projectile or spell hidden from the player’s view, often used when visual representation is unnecessary.</param>
    /// <param name="grid">Allows the effect to interact with each grid (tile or cell) it moves through, which can alter terrain or affect grid-based elements like traps.</param>
    /// <param name="item">Enables the effect to interact with items it encounters, possibly damaging or destroying them if applicable.</param>
    /// <param name="kill">Permits the projectile or spell to affect monsters or entities in its path, enabling damage or other targeted effects.</param>
    /// <param name="stop">Causes a projectile or spell to stop when it hits an obstacle, halting further movement or effects along its path.</param>
    /// <returns></returns>
    public bool Fire(int who, int rad, int y, int x, int dam, bool jump, bool beam, bool thru, bool hide, bool grid, bool item, bool kill, bool stop)
    {
        int i, dist;
        int y1, x1;
        int msec = Constants.DelayFactorInMilliseconds; // TODO: This can be per projectile
        GridTile cPtr;
        bool notice = false;
        bool visual = false;
        bool drawn = false;
        bool breath = false;
        bool blind = Game.BlindnessTimer.Value != 0;
        int grids = 0;
        int[] gx = new int[256];
        int[] gy = new int[256];
        int[] gm = new int[32]; // TODO: Is this the maximum distance of travel?
        int gmRad = rad;
        if (jump)
        {
            x1 = x;
            y1 = y;
        }
        else if (who == 0)
        {
            x1 = Game.MapX.IntValue;
            y1 = Game.MapY.IntValue;
        }
        else
        {
            x1 = Game.Monsters[who].MapX;
            y1 = Game.Monsters[who].MapY;
        }
        int ySaver = y1;
        int xSaver = x1;
        int y2 = y;
        int x2 = x;
        if (thru)
        {
            if (x1 == x2 && y1 == y2)
            {
                thru = false;
            }
        }
        if (rad < 0)
        {
            rad = 0 - rad;
            breath = true;
            hide = true;
        }
        for (dist = 0; dist < 32; dist++)
        {
            gm[dist] = 0;
        }
        Game.HandleStuff();
        x = x1;
        y = y1;
        dist = 0;
        while (true)
        {
            if (beam)
            {
                gy[grids] = y;
                gx[grids] = x;
                grids++;
            }
            if (!blind && !hide && dist != 0 && beam && Game.PanelContains(y, x) && Game.PlayerHasLosBold(y, x))
            {
                if (ImpactProjectileGraphic != null)
                {
                    Game.ConsoleView.PutCharAtMapLocation(ImpactProjectileGraphic.Character, ImpactProjectileGraphic.Color, y, x);
                }
            }
            cPtr = Game.Map.Grid[y][x];
            if (dist != 0 && !Game.GridPassable(y, x))
            {
                break;
            }
            if (!thru && x == x2 && y == y2)
            {
                break;
            }
            if (cPtr.MonsterIndex != 0 && dist != 0 && stop)
            {
                break;
            }
            Game.MoveOneStepTowards(out int y9, out int x9, y, x, y1, x1, y2, x2);
            if (!Game.GridPassable(y9, x9) && rad > 0)
            {
                break;
            }
            dist++;
            if (dist > Constants.MaxRange) // TODO: This should be per projectile
            {
                break;
            }
            if (!blind && !hide)
            {
                if (Game.PlayerHasLosBold(y9, x9) && Game.PanelContains(y9, x9))
                {
                    if (BoltProjectileGraphic != null)
                    {
                        char directionalCharacter = BoltProjectileGraphic.Character;
                        if (directionalCharacter == '|')
                        {
                            directionalCharacter = BoltChar(y, x, y9, x9);
                        }
                        Game.ConsoleView.PutCharAtMapLocation(directionalCharacter, BoltProjectileGraphic.Color, y9, x9);
                        Game.ConsoleView.MoveCursorTo(y9, x9);
                        Game.UpdateScreen();
                        visual = true;
                        Game.Pause(msec); // This actually allows the screen to update.
                        Game.ConsoleView.RefreshMapLocation(y9, x9);
                        Game.UpdateScreen();
                    }
                }
                else if (visual)
                {
                    Game.Pause(msec);
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
            if (beam && grids > 0)
            {
                grids--;
            }
            if (breath)
            {
                int brad = 0;
                int bdis = 0;
                bool done = false;
                hide = false;
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
                                if (!Game.InBounds(y, x))
                                {
                                    continue;
                                }
                                if (Game.Distance(y1, x1, y, x) != bdis)
                                {
                                    continue;
                                }
                                if (Game.Distance(by, bx, y, x) != cdis)
                                {
                                    continue;
                                }
                                if (!Game.Los(by, bx, y, x))
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
                    Game.MoveOneStepTowards(out by, out bx, by, bx, y1, x1, y2, x2);
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
                            if (!Game.InBounds2(y, x))
                            {
                                continue;
                            }
                            if (Game.Distance(y2, x2, y, x) != dist)
                            {
                                continue;
                            }
                            if (GetType().Name == "ProjectDisintegrate")
                            {
                                if (Game.CaveValidBold(y, x))
                                {
                                    Game.RevertTileToBackground(y, x);
                                }
                                Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
                                Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
                                Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
                                Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
                            }
                            else
                            {
                                if (!Game.Los(y2, x2, y, x))
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
        if (!blind && !hide)
        {
            for (int t = 0; t <= gmRad; t++)
            {
                for (i = gm[t]; i < gm[t + 1]; i++)
                {
                    y = gy[i];
                    x = gx[i];
                    if (Game.PlayerHasLosBold(y, x) && Game.PanelContains(y, x))
                    {
                        if (ImpactProjectileGraphic != null)
                        {
                            drawn = true;
                            Game.ConsoleView.PutCharAtMapLocation(ImpactProjectileGraphic.Character, ImpactProjectileGraphic.Color, y, x);
                        }
                    }
                }
                if (ImpactProjectileGraphic != null)
                {
                    Game.ConsoleView.MoveCursorTo(y2, x2);
                    Game.UpdateScreen();
                    if (visual || drawn)
                    {
                        Game.Pause(msec);
                    }
                }
            }
            if (drawn)
            {
                for (i = 0; i < grids; i++)
                {
                    y = gy[i];
                    x = gx[i];
                    if (Game.PlayerHasLosBold(y, x) && Game.PanelContains(y, x))
                    {
                        Game.ConsoleView.RefreshMapLocation(y, x);
                    }
                }
                Game.ConsoleView.MoveCursorTo(y2, x2);
                Game.UpdateScreen();
            }
        }

        if (EffectAnimation != null)
        {
            EffectAnimation.Animate(gy, gx);
        }

        if (grid)
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
                if (FloorEffect.Apply(y, x))
                {
                    notice = true;
                }
            }
        }
        if (item)
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
                if (ItemEffect.Apply(who, y, x))
                {
                    notice = true;
                }
            }
        }
        if (kill)
        {
            int projectMn = 0;
            int projectMx = 0;
            int projectMy = 0;
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
                    if (MonsterEffect.Apply(who, dist, y, x, dam, ref projectMn, ref projectMx, ref projectMy) == IdentifiedResultEnum.True)
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
                    MonsterRace refPtr = Game.Monsters[cPtr.MonsterIndex].Race;
                    if (refPtr.Reflecting && Game.DieRoll(10) != 1 && distHack > 1 && GetType().Name != "ProjectWizardBolt")
                    {
                        int tY, tX;
                        int maxAttempts = 10;
                        do
                        {
                            tY = ySaver - 1 + Game.DieRoll(3);
                            tX = xSaver - 1 + Game.DieRoll(3);
                            maxAttempts--;
                        } while (maxAttempts > 0 && Game.InBounds2(tY, tX) && !Game.Los(y, x, tY, tX));
                        if (maxAttempts < 1)
                        {
                            tY = ySaver;
                            tX = xSaver;
                        }
                        if (Game.Monsters[cPtr.MonsterIndex].IsVisible)
                        {
                            Game.MsgPrint("The attack bounces!");
                            refPtr.Knowledge.Characteristics.Reflecting = true;
                        }
                        Fire(cPtr.MonsterIndex, 0, tY, tX, dam, jump: jump, beam: beam, thru: thru, hide: hide, grid: grid, item: item, kill: kill, stop: stop);
                    }
                    else
                    {
                        if (MonsterEffect.Apply(who, dist, y, x, dam, ref projectMn, ref projectMx, ref projectMy) == IdentifiedResultEnum.True)
                        {
                            notice = true;
                        }
                    }
                }
            }
            if (who == 0 && projectMn == 1 && !jump)
            {
                x = projectMx;
                y = projectMy;
                cPtr = Game.Map.Grid[y][x];
                if (cPtr.MonsterIndex != 0)
                {
                    Monster mPtr = Game.Monsters[cPtr.MonsterIndex];
                    if (mPtr.IsVisible)
                    {
                        Game.HealthTrack(cPtr.MonsterIndex);
                    }
                }
            }
        }
        if (kill)
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
                if (x == Game.MapX.IntValue && y == Game.MapY.IntValue && who != 0)
                {
                    // Check to see if the projectile attack bounces off the player.
                    if (!CheckBounceOffPlayer(who, dam, rad))
                    {
                        // Allow the projectile to perform any effects on the player.
                        if (PlayerEffect.ApplyEffect(who, dist, y, x, dam, rad) == IdentifiedResultEnum.True)
                        {
                            // Disturb the player.
                            Game.Disturb(true);

                            // The effects were noticed.
                            notice = true;
                        }
                    }
                }
            }
        }
        return notice;
    }

    /// <summary>

    /// <summary>
    /// Performs a reflection test of the projectile on the player and returns true, if the projectile is reflected.
    /// </summary>
    /// <param name="who"></param>
    /// <param name="dam"></param>
    /// <param name="aRad"></param>
    /// <returns></returns>
    protected bool CheckBounceOffPlayer(int who, int dam, int aRad)
    {
        if (Game.HasReflection && aRad == 0 && Game.DieRoll(10) != 1)
        {
            bool blind = Game.BlindnessTimer.Value != 0;
            Game.MsgPrint(blind ? "Something bounces!" : "The attack bounces!");

            int tY;
            int tX;
            int maxAttempts = 10;
            do
            {
                tY = Game.Monsters[who].MapY - 1 + Game.DieRoll(3);
                tX = Game.Monsters[who].MapX - 1 + Game.DieRoll(3);
                maxAttempts--;
            } while (maxAttempts > 0 && Game.InBounds2(tY, tX) && !Game.PlayerHasLosBold(tY, tX));
            if (maxAttempts < 1)
            {
                tY = Game.Monsters[who].MapY;
                tX = Game.Monsters[who].MapX;
            }
            Fire(0, 0, tY, tX, dam, stop: true, kill: true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false);
            Game.Disturb(true);
            return true;
        }
        return false;
    }

    private char BoltChar(int y, int x, int ny, int nx)
    {
        if (ny == y && nx == x)
        {
            return '*'; // TODO: This can be a property for each projectile
        }
        if (ny == y)
        {
            return '-'; // TODO: This can be a property for each projectile
        }
        if (nx == x)
        {
            return '|'; // TODO: This can be a property for each projectile
        }
        if (ny - y == x - nx)
        {
            return '/'; // TODO: This can be a property for each projectile
        }
        if (ny - y == nx - x)
        {
            return '\\'; // TODO: This can be a property for each projectile
        }
        return '*'; // TODO: This can be a property for each projectile
    }

    protected FloorEffect FloorEffect { get; private set; }

    /// <summary>
    /// Perform any effect needed on the floor and returns true, if the effect was noticed.  Does nothing and returns false, by default.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    protected virtual string FloorEffectBindingKey { get; } = nameof(UnnoticedFloorEffect);

    /// <summary>
    /// Returns the <see cref="ItemEffect"/> that perform the effect needed on the item and returns true, if the effect was noticed.  Does nothing and return false, by default.  This property is bound
    /// from the <see cref="ItemEffectBindingKey"/> property during the binding phase.
    /// </summary>
    protected ItemEffect ItemEffect { get; private set; }

    /// <summary>
    /// Returns the binding key for the <see cref="ItemEffect"></see> object to perform the effect needed on an item.  This property is used to bind the <see cref="ItemEffect"></see> property during the
    /// binding phase.
    /// </summary>
    protected virtual string ItemEffectBindingKey { get; } = nameof(UnnoticedItemEffect);

    protected PlayerEffectUniversalScript PlayerEffect { get; private set; }

    protected virtual string PlayerEffectBindingKey { get; } = nameof(NoticedPlayerEffect);

    protected MonsterEffect MonsterEffect { get; private set; }

    /// <summary>
    /// Perform any effect needed on a monster and returns true, if the effect was noticed.
    /// </summary>
    /// <param name="who">Represents who performed the attack.  A value of 0, means the player.  Otherwise, who represents the MonsterIndex.</param>
    /// <param name="dam">Represents the amount of damage to inflict.  This damage value is automatically decreased with the distance from the attacker.</param>
    /// <param name="mPtr">Represents the monster to affect.</param>
    /// <param name="r">Represents the distance from the attacker.</param>
    /// <returns></returns>
    protected virtual string MonsterEffectBindingKey { get; }
}
