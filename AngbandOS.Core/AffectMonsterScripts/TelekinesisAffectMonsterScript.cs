// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal class TelekinesisAffectMonsterScript : AffectMonsterScript
{
    private TelekinesisAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        if (seen)
        {
            obvious = true;
        }
        int doDist = 7;
        int doStun = Game.DiceRoll((Game.ExperienceLevel.IntValue / 10) + 3, dam) + 1;
        if (rPtr.Unique || rPtr.Level > 5 + Game.DieRoll(dam))
        {
            doStun = 0;
            obvious = false;
        }
        if (doDist != 0)
        {
            if (seen)
            {
                obvious = true;
            }
            note = " disappears!";
            mPtr.TeleportAway(doDist);
        }
        else if (doStun != 0 && !rPtr.BreatheSound && !rPtr.BreatheForce)
        {
            if (seen)
            {
                obvious = true;
            }
            int tmp;
            if (mPtr.StunLevel != 0)
            {
                note = " is more dazed.";
                tmp = mPtr.StunLevel + (doStun / 2);
            }
            else
            {
                note = " is dazed.";
                tmp = doStun;
            }
            mPtr.StunLevel = tmp < 200 ? tmp : 200;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }
}
