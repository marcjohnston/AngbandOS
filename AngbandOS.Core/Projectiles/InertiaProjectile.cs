﻿// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class InertiaProjectile : Projectile
    {
        public InertiaProjectile(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "OrangeBolt";

        protected override string ImpactGraphic => "OrangeSplat";

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
            if (rPtr.BreatheInertia)
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
            }
            else
            {
                if (rPtr.Unique ||
                    rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
                {
                    obvious = false;
                }
                else
                {
                    if (mPtr.Speed > 60)
                    {
                        mPtr.Speed -= 10;
                    }
                    note = " starts moving slower.";
                }
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
                SaveGame.MsgPrint("You are hit by something slow!");
            }
            SaveGame.Player.TimedSlow.AddTimer(Program.Rng.RandomLessThan(4) + 4);
            SaveGame.Player.TakeHit(dam, killer);
            return true;
        }
    }
}