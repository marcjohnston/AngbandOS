// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectOldSpeed : Projectile
    {
        public ProjectOldSpeed(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightBlueBullet";

        protected override string EffectAnimation => "BrightBlueSwirl";

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            return false;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            if (seen)
            {
                obvious = true;
            }
            if (mPtr.Speed < 150)
            {
                mPtr.Speed += 10;
            }
            string? note = " starts moving faster.";
            dam = 0;
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return obvious;
        }

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = SaveGame.Player.TimedBlindness.TimeRemaining != 0;
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by something!");
            }
            SaveGame.Player.TimedHaste.SetTimer(SaveGame.Player.TimedHaste.TimeRemaining + Program.Rng.DieRoll(5));
            return true;
        }
    }
}