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
    internal class TurnEvilProjectile : Projectile
    {
        private TurnEvilProjectile(SaveGame saveGame) : base(saveGame) { }

        protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<WhiteControlAnimation>();

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
            bool obvious = false;
            bool skipped = false;
            int doFear = 0;
            string? note = null;
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
                doFear = Program.Rng.DiceRoll(3, dam / 2) + 1;
                if (rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
                {
                    note = " is unaffected!";
                    obvious = false;
                    doFear = 0;
                }
            }
            else
            {
                skipped = true;
            }
            dam = 0;
            if (skipped)
            {
                return false;
            }
            ApplyProjectileDamageToMonster(who, mPtr, dam, note, doFear);
            return obvious;
        }
    }
}