// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class ProjectDispLiving : Projectile
    {
        public ProjectDispLiving(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "GreenSplat";

        protected override string EffectAnimation => "GreenExpand";

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            MonsterRace rPtr = mPtr.Race;
            return !rPtr.Undead && !rPtr.Nonliving;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            bool skipped = false;
            string? note = null;
            string? noteDies = null;
            if (ProjectileAngersMonster(mPtr))
            {
                if (seen)
                {
                    obvious = true;
                }
                note = " shudders.";
                noteDies = " dissolves!";
            }
            else
            {
                skipped = true;
                dam = 0;
            }
            if (skipped)
            {
                return false;
            }
            ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
            return obvious;
        }
    }
}