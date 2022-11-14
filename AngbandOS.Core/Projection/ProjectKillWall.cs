// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;

using AngbandOS.Core.Interface;
using AngbandOS.Core;
using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Projection
{
    internal class ProjectKillWall : Projectile
    {
        public ProjectKillWall(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "";

        protected override string EffectAnimation => "BrownSwirl";

        protected override bool AffectFloor(int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            bool obvious = false;
            if (SaveGame.Level.GridPassable(y, x))
            {
                return false;
            }
            if (cPtr.FeatureType.IsPermanent)
            {
                return false;
            }
            if (cPtr.FeatureType.Name.Contains("Treas"))
            {
                if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
                {
                    SaveGame.MsgPrint("The vein turns into mud!");
                    SaveGame.MsgPrint("You have found something!");
                    obvious = true;
                }
                cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                SaveGame.Level.RevertTileToBackground(y, x);
                SaveGame.Level.PlaceGold(y, x);
            }
            else if (cPtr.FeatureType.Name.Contains("Magma") || cPtr.FeatureType.Name.Contains("Quartz"))
            {
                if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
                {
                    SaveGame.MsgPrint("The vein turns into mud!");
                    obvious = true;
                }
                cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                SaveGame.Level.RevertTileToBackground(y, x);
            }
            else if (cPtr.FeatureType.IsWall)
            {
                if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
                {
                    SaveGame.MsgPrint("The wall turns into mud!");
                    obvious = true;
                }
                cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                SaveGame.Level.RevertTileToBackground(y, x);
            }
            else if (cPtr.FeatureType.Name == "Rubble")
            {
                if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
                {
                    SaveGame.MsgPrint("The rubble turns into mud!");
                    obvious = true;
                }
                cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                SaveGame.Level.RevertTileToBackground(y, x);
                if (Program.Rng.RandomLessThan(100) < 10)
                {
                    if (SaveGame.Level.PlayerCanSeeBold(y, x))
                    {
                        SaveGame.MsgPrint("There was something buried in the rubble!");
                        obvious = true;
                    }
                    SaveGame.Level.PlaceObject(y, x, false, false);
                }
            }
            else
            {
                if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
                {
                    SaveGame.MsgPrint("The door turns into mud!");
                    obvious = true;
                }
                cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                SaveGame.Level.RevertTileToBackground(y, x);
            }
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent | UpdateFlags.UpdateMonsters);
            return obvious;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string note = null;
            string noteDies = NoteDiesOrIsDestroyed(rPtr);
            string mName = mPtr.MonsterDesc(0);
            if (who == 0 && (mPtr.Mind & Constants.SmFriendly) != 0)
            {
                bool getAngry = (rPtr.Flags3 & MonsterFlag3.HurtByRock) != 0;
                if (getAngry && who == 0)
                {
                    SaveGame.MsgPrint($"{mName} gets angry!");
                    mPtr.Mind &= ~Constants.SmFriendly;
                }
            }
            if ((rPtr.Flags3 & MonsterFlag3.HurtByRock) != 0)
            {
                if (seen)
                {
                    obvious = true;
                }
                if (seen)
                {
                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.HurtByRock;
                }
                note = " loses some skin!";
                noteDies = " dissolves!";
            }
            else
            {
                dam = 0;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
            {
                if (who != 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
            {
                if (who > 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if (dam > mPtr.Health)
            {
                note = noteDies;
            }
            if (who != 0)
            {
                if (SaveGame.TrackedMonsterIndex == cPtr.MonsterIndex)
                {
                    SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                }
                mPtr.SleepLevel = 0;
                mPtr.Health -= dam;
                if (mPtr.Health < 0)
                {
                    bool sad = (mPtr.Mind & Constants.SmFriendly) != 0 && !mPtr.IsVisible;
                    SaveGame.MonsterDeath(cPtr.MonsterIndex);
                    SaveGame.Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                    if (string.IsNullOrEmpty(note) == false)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    if (sad)
                    {
                        SaveGame.MsgPrint("You feel sad for a moment.");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(note) == false && seen)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    else if (dam > 0)
                    {
                        SaveGame.Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                }
            }
            else
            {
                if (SaveGame.Level.Monsters.DamageMonster(cPtr.MonsterIndex, dam, out bool fear, noteDies))
                {
                }
                else
                {
                    if (string.IsNullOrEmpty(note) == false && seen)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    else if (dam > 0)
                    {
                        SaveGame.Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                    if (fear && mPtr.IsVisible)
                    {
                        SaveGame.PlaySound(SoundEffect.MonsterFlees);
                        SaveGame.MsgPrint($"{mName} flees in terror!");
                    }
                }
            }
            return obvious;
        }
    }
}