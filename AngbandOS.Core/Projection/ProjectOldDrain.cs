// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectOldDrain : Projectile
    {
        public ProjectOldDrain(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BlackBolt";

        protected override string EffectAnimation => "BlackContract";

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
            if (rPtr.Undead || rPtr.Demon || rPtr.Nonliving || "Egv".Contains(rPtr.Character.ToString()))
            {
                if (rPtr.Undead)
                {
                    if (seen)
                    {
                        rPtr.Knowledge.Characteristics.Undead = true;
                    }
                }
                if (rPtr.Demon)
                {
                    if (seen)
                    {
                        rPtr.Knowledge.Characteristics.Demon = true;
                    }
                }
                note = " is unaffected!";
                obvious = false;
                dam = 0;
            }
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return obvious;
        }
    }
}