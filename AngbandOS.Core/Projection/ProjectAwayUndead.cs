// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;

using AngbandOS.Core.Interface;
using AngbandOS.Core;
using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Projection
{
    internal class ProjectAwayUndead : Projectile
    {
        public ProjectAwayUndead(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "PinkBullet";

        protected override string EffectAnimation => "PinkSwirl";

        protected override string ImpactGraphic => "PinkBullet";

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            bool skipped = false;
            int doDist = 0;
            string note = null;
            string noteDies = NoteDiesOrIsDestroyed(rPtr);
            string mName = mPtr.MonsterDesc(0);
            if ((rPtr.Flags3 & MonsterFlag3.Undead) != 0)
            {
                bool resistsTele = false;
                if ((rPtr.Flags3 & MonsterFlag3.ResistTeleport) != 0)
                {
                    if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                    {
                        if (seen)
                        {
                            rPtr.Knowledge.RFlags3 |= MonsterFlag3.ResistTeleport;
                        }
                        note = " is unaffected!";
                        resistsTele = true;
                    }
                    else if (rPtr.Level > Program.Rng.DieRoll(100))
                    {
                        if (seen)
                        {
                            rPtr.Knowledge.RFlags3 |= MonsterFlag3.ResistTeleport;
                        }
                        note = " resists!";
                        resistsTele = true;
                    }
                }
                if (!resistsTele)
                {
                    if (seen)
                    {
                        obvious = true;
                    }
                    if (seen)
                    {
                        rPtr.Knowledge.RFlags3 |= MonsterFlag3.Undead;
                    }
                    doDist = dam;
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
            if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
            {
                if (who != 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
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
            else if (doDist != 0)
            {
                if (seen)
                {
                    obvious = true;
                }
                note = " disappears!";
                mPtr.TeleportAway(SaveGame, doDist);
                cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
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
                    bool sad = (mPtr.Mind & Constants.SmFriendly) != 0 && !mPtr.IsVisible;
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