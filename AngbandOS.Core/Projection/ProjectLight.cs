// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectLight : Projectile
    {
        public ProjectLight(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightWhiteBolt";

        protected override string EffectAnimation => "BrightWhiteCloud";

        protected override bool AffectFloor(int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            bool obvious = false;
            cPtr.TileFlags.Set(GridTile.SelfLit);
            SaveGame.Level.NoteSpot(y, x);
            SaveGame.Level.RedrawSingleLocation(y, x);
            if (SaveGame.Level.PlayerCanSeeBold(y, x))
            {
                obvious = true;
            }
            if (cPtr.MonsterIndex != 0)
            {
                SaveGame.Level.Monsters.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
            }
            return obvious;
        }

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            // Only friends that are hurt by light are affected.
            MonsterRace rPtr = mPtr.Race;
            return rPtr.HurtByLight;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string note = null;
            string noteDies = NoteDiesOrIsDestroyed(rPtr);
            string mName = mPtr.Name;
            if (rPtr.HurtByLight)
            {
                if (seen)
                {
                    obvious = true;
                }
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.HurtByLight = true;
                }
                note = " cringes from the light!";
                noteDies = " shrivels away in the light!";
            }
            else
            {
                dam = 0;
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

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = SaveGame.Player.TimedBlindness != 0;
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.IndefiniteVisibleName;
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by something!");
            }
            if (SaveGame.Player.HasLightResistance)
            {
                dam *= 4;
                dam /= Program.Rng.DieRoll(6) + 6;
            }
            else if (!blind && !SaveGame.Player.HasBlindnessResistance)
            {
                SaveGame.Player.SetTimedBlindness(SaveGame.Player.TimedBlindness + Program.Rng.DieRoll(5) + 2);
            }
            if (SaveGame.Player.Race.IsBurnedBySunlight)
            {
                SaveGame.MsgPrint("The light scorches your flesh!");
                dam *= 2;
            }
            SaveGame.Player.TakeHit(dam, killer);
            if (SaveGame.Player.TimedEtherealness != 0)
            {
                SaveGame.Player.TimedEtherealness = 0;
                SaveGame.MsgPrint("The light forces you out of your incorporeal shadow form.");
                SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMap);
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            }
            return true;
        }
    }
}