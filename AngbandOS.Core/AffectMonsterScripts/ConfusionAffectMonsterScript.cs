// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal class ConfusionAffectMonsterScript : AffectMonsterScript
{
    private ConfusionAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

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
        int doConf = (10 + Game.DieRoll(15) + r) / (r + 1);
        if (rPtr.BreatheConfusion)
        {
            note = " resists.";
            dam *= 2;
            dam /= Game.DieRoll(6) + 6;
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
}
