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
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string note = null;
            string noteDies = NoteDiesOrIsDestroyed(rPtr);
            string mName = mPtr.Name;
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
            if (rPtr.Guardian)
            {
                if (who != 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if (rPtr.Guardian)
            {
                if (who > 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if (dam > mPtr.Health)
            {
                note = noteDies;
            }
            if (who != 0)
            {
                if (SaveGame.TrackedMonsterIndex == cPtr.MonsterIndex)
                {
                    SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                }
                mPtr.SleepLevel = 0;
                mPtr.Health -= dam;
                if (mPtr.Health < 0)
                {
                    bool sad = mPtr.SmFriendly && !mPtr.IsVisible;
                    SaveGame.MonsterDeath(cPtr.MonsterIndex);
                    SaveGame.Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                    if (string.IsNullOrEmpty(note) == false)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    if (sad)
                    {
                        SaveGame.MsgPrint("You feel sad for a moment.");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(note) == false && seen)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    else if (dam > 0)
                    {
                        SaveGame.Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                }
            }
            else
            {
                if (SaveGame.Level.Monsters.DamageMonster(cPtr.MonsterIndex, dam, out bool fear, noteDies))
                {
                }
                else
                {
                    if (string.IsNullOrEmpty(note) == false && seen)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    else if (dam > 0)
                    {
                        SaveGame.Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                    if (fear && mPtr.IsVisible)
                    {
                        SaveGame.PlaySound(SoundEffect.MonsterFlees);
                        SaveGame.MsgPrint($"{mName} flees in terror!");
                    }
                }
            }
            return obvious;
        }
    }
}