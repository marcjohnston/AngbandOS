// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class ConfusionProjectile : Projectile
    {
        private ConfusionProjectile(SaveGame saveGame) : base(saveGame) { }

        protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GreySplatProjectileGraphic>();

        protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<GreyQuestionAnimation>();

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
            int doConf = (10 + Program.Rng.DieRoll(15) + r) / (r + 1);
            if (rPtr.BreatheConfusion)
            {
                note = " resists.";
                dam *= 2;
                dam /= Program.Rng.DieRoll(6) + 6;
            }
            else if (rPtr.ImmuneConfusion)
            {
                note = " resists somewhat.";
                dam /= 2;
            }
            if (doConf != 0 && !rPtr.ImmuneConfusion && !rPtr.BreatheConfusion && !rPtr.BreatheChaos)
            {
                int tmp;
                if (mPtr.ConfusionLevel != 0)
                {
                    note = " looks more confused.";
                    tmp = mPtr.ConfusionLevel + (doConf / 2);
                }
                else
                {
                    note = " looks confused.";
                    tmp = doConf;
                }
                mPtr.ConfusionLevel = tmp < 200 ? tmp : 200;
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
                SaveGame.MsgPrint("You are hit by something puzzling!");
            }
            if (SaveGame.Player.HasConfusionResistance)
            {
                dam *= 5;
                dam /= Program.Rng.DieRoll(6) + 6;
            }
            if (!SaveGame.Player.HasConfusionResistance)
            {
                SaveGame.Player.TimedConfusion.AddTimer(Program.Rng.DieRoll(20) + 10);
            }
            SaveGame.Player.TakeHit(dam, killer);
            return true;
        }
    }
}