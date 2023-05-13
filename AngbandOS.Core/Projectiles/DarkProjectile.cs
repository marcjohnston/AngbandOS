// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    [Serializable]
    internal class DarkProjectile : Projectile
    {
        private DarkProjectile(SaveGame saveGame) : base(saveGame) { }

        protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BlackBoltProjectileGraphic>();

        protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BlackSplatProjectileGraphic>();

        protected override bool AffectFloor(int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            bool obvious = SaveGame.Level.PlayerCanSeeBold(y, x);
            cPtr.TileFlags.Clear(GridTile.SelfLit);
            if (cPtr.FeatureType.IsOpenFloor)
            {
                cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                SaveGame.Level.NoteSpot(y, x);
            }
            SaveGame.Level.RedrawSingleLocation(y, x);
            if (cPtr.MonsterIndex != 0)
            {
                SaveGame.Level.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
            }
            return obvious;
        }

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            // Invisible friends are not affected by darkness.
            return mPtr.IsVisible;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string? note = null;

            if (seen)
            {
                obvious = true;
            }
            if (rPtr.BreatheDark || rPtr.Orc || rPtr.HurtByLight)
            {
                note = " resists.";
                dam *= 2;
                dam /= Program.Rng.DieRoll(6) + 6;
            }
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return obvious;
        }

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = SaveGame.Player.TimedBlindness.TurnsRemaining != 0;
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.IndefiniteVisibleName;
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by something!");
            }
            if (SaveGame.Player.HasDarkResistance)
            {
                dam *= 4;
                dam /= Program.Rng.DieRoll(6) + 6;
                if (!SaveGame.Player.Race.IsDamagedByDarkness)
                {
                    dam = 0;
                }
            }
            else if (!blind && !SaveGame.Player.HasBlindnessResistance)
            {
                SaveGame.Player.TimedBlindness.AddTimer(Program.Rng.DieRoll(5) + 2);
            }
            if (SaveGame.Player.TimedEtherealness.TurnsRemaining != 0)
            {
                SaveGame.Player.RestoreHealth(dam);
            }
            else
            {
                SaveGame.Player.TakeHit(dam, killer);
            }
            return true;
        }
    }
}