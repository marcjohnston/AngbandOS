namespace AngbandOS.Projection
{
    internal class ProjectDeathRay : Projectile
    {
        public ProjectDeathRay(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "CopperBolt";

        protected override string EffectAnimation => "CopperContract";

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
            if (rPtr.Undead || rPtr.Nonliving)
            {
                if (rPtr.Undead)
                {
                    if (seen)
                    {
                        rPtr.Knowledge.Characteristics.Undead = true;
                    }
                }
                note = " is immune.";
                obvious = false;
                dam = 0;
            }
            else if ((rPtr.Unique && Program.Rng.DieRoll(888) != 666) ||
                     (rPtr.Level + Program.Rng.DieRoll(20) >
                     Program.Rng.DieRoll(dam + Program.Rng.DieRoll(10)) && Program.Rng.DieRoll(100) != 66))
            {
                note = " resists!";
                obvious = false;
                dam = 0;
            }
            else
            {
                dam = SaveGame.Player.Level * 200;
            }
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return obvious;
        }
    }
}