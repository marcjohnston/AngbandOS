// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal class TeleportAwayEvilAffectMonsterScript : AffectMonsterScript
{
    private TeleportAwayEvilAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        GridTile cPtr = Game.Map.Grid[mPtr.MapY][mPtr.MapX];
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        bool skipped = false;
        int doDist = 0;
        string? note = null;
        if (rPtr.Evil)
        {
            bool resistsTele = false;
            if (rPtr.ResistTeleport)
            {
                if (rPtr.Unique)
                {
                    if (seen)
                    {
                        rPtr.Knowledge.Characteristics.ResistTeleport = true;
                    }
                    note = " is unaffected!";
                    resistsTele = true;
                }
                else if (rPtr.Level > Game.DieRoll(100))
                {
                    if (seen)
                    {
                        rPtr.Knowledge.Characteristics.ResistTeleport = true;
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
                    rPtr.Knowledge.Characteristics.Evil = true;
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
        if (doDist != 0)
        {
            if (seen)
            {
                obvious = true;
            }
            note = " disappears!";
            mPtr.TeleportAway(doDist);
            cPtr = Game.Map.Grid[mPtr.MapY][mPtr.MapX];
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }
}
