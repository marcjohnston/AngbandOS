// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectNuke : Projectile
    {
        public ProjectNuke(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightChartreuseSplat";

        protected override string EffectAnimation => "ChartreuseFlash";

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            bool doPoly = false;
            string? note = null;
            if (seen)
            {
                obvious = true;
            }
            if (rPtr.ImmunePoison)
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ImmunePoison = true;
                }
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                doPoly = true;
            }
            if (rPtr.Unique)
            {
                doPoly = false;
            }
            if (rPtr.Guardian)
            {
                doPoly = false;
            }
            if (doPoly && Program.Rng.DieRoll(90) > rPtr.Level)
            {
                note = " is unaffected!";
                bool charm = mPtr.SmFriendly;
                int tmp = SaveGame.PolymorphMonster(mPtr.Race);
                if (tmp != mPtr.Race.Index)
                {
                    note = " changes!";
                    dam = 0;
                    SaveGame.Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                    MonsterRace race = SaveGame.SingletonRepository.MonsterRaces[tmp];
                    SaveGame.Level.Monsters.PlaceMonsterAux(mPtr.MapY, mPtr.MapX, race, false, false, charm);
                    mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
                }
            }
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return obvious;
        }

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = SaveGame.Player.TimedBlindness.TimeRemaining != 0;
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.IndefiniteVisibleName;
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by radiation!");
            }
            if (SaveGame.Player.HasPoisonResistance)
            {
                dam = ((2 * dam) + 2) / 5;
            }
            if (SaveGame.Player.TimedPoisonResistance.TimeRemaining != 0)
            {
                dam = ((2 * dam) + 2) / 5;
            }
            SaveGame.Player.TakeHit(dam, killer);
            if (!(SaveGame.Player.HasPoisonResistance || SaveGame.Player.TimedPoisonResistance.TimeRemaining != 0))
            {
                SaveGame.Player.TimedPoison.SetTimer(SaveGame.Player.TimedPoison.TimeRemaining + Program.Rng.RandomLessThan(dam) + 10);
                if (Program.Rng.DieRoll(5) == 1)
                {
                    SaveGame.MsgPrint("You undergo a freakish metamorphosis!");
                    if (Program.Rng.DieRoll(4) == 1)
                    {
                        SaveGame.Player.PolymorphSelf(SaveGame);
                    }
                    else
                    {
                        SaveGame.Player.ShuffleAbilityScores();
                    }
                }
                if (Program.Rng.DieRoll(6) == 1)
                {
                    SaveGame.Player.InvenDamage(SaveGame.SetAcidDestroy, 2);
                }
            }
            return true;
        }
    }
}