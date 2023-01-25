// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectCharm : Projectile
    {
        public ProjectCharm(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "";

        protected override string EffectAnimation => "GreyControl";

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            return false;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string? note = null;
            dam += SaveGame.Player.AbilityScores[Ability.Charisma].ConRecoverySpeed - 1;
            if (seen)
            {
                obvious = true;
            }
            if (rPtr.Unique || rPtr.ImmuneConfusion || rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 5)
            {
                if (rPtr.ImmuneConfusion)
                {
                    if (seen)
                    {
                        rPtr.Knowledge.Characteristics.ImmuneConfusion = true;
                    }
                }
                note = " is unaffected!";
                obvious = false;
            }
            else if (SaveGame.Player.HasAggravation || rPtr.Guardian)
            {
                note = " hates you too much!";
            }
            else
            {
                note = " suddenly seems friendly!";
                mPtr.SmFriendly = true;
            }
            dam = 0;
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return obvious;
        }
    }
}