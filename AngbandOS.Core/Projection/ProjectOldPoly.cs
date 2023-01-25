// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectOldPoly : Projectile
    {
        public ProjectOldPoly(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "PurpleSplat";

        protected override string EffectAnimation => "PurpleSparkle";

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            // The attack will turn friends 1 in 8 times.
            return (Program.Rng.DieRoll(8) == 1);
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string? note = null;
            if (seen)
            {
                obvious = true;
            }
            bool doPoly = true;
            if (rPtr.Unique || rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
            {
                note = " is unaffected!";
                doPoly = false;
                obvious = false;
            }
            dam = 0;
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
    }
}