﻿// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class DispEvilProjectile : Projectile
    {
        public DispEvilProjectile(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "RedSplat";

        protected override string EffectAnimation => "RedExpand";

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            // Only evil friends are affected.
            MonsterRace rPtr = mPtr.Race;
            return rPtr.Evil;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            string? note = null;
            string? noteDies = " dissolves!";
            bool obvious = false;
            if (rPtr.Evil)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.Evil = true;
                }
                if (seen)
                {
                    obvious = true;
                }
                note = " shudders.";
            }
            else
            {
                return false;
            }
            ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
            return obvious;
        }
    }
}