// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectDispAll : Projectile
    {
        public ProjectDispAll(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightPinkSplat";

        protected override string EffectAnimation => "BrightPinkExpand";

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            return false;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string noteDies = " dissolves!";
            if (seen)
            {
                obvious = true;
            }
            string? note = " shudders.";
            ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
            return obvious;
        }
    }
}