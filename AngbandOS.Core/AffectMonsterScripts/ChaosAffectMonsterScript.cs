// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal class ChaosAffectMonsterScript : AffectMonsterScript
{
    private ChaosAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

    public override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        GridTile cPtr = Game.Map.Grid[mPtr.MapY][mPtr.MapX];
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        if (seen)
        {
            obvious = true;
        }
        bool doPoly = true;
        int doConf = (5 + Game.DieRoll(11) + r) / (r + 1);
        if (rPtr.BreatheChaos ||
            (rPtr.Demon && Game.DieRoll(3) == 1))
        {
            note = " resists.";
            dam *= 3;
            dam /= Game.DieRoll(6) + 6;
            doPoly = false;
        }
        if (rPtr.Unique)
        {
            doPoly = false;
        }
        if (rPtr.Guardian)
        {
            doPoly = false;
        }
        if (doPoly && Game.DieRoll(90) > rPtr.Level)
        {
            note = " is unaffected!";
            bool charm = mPtr.IsPet;
            int tmp = Game.PolymorphMonsterRace(mPtr.Race);
            if (tmp != mPtr.Race.Index)
            {
                note = " changes!";
                dam = 0;
                Game.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                MonsterRace race = Game.SingletonRepository.Get<MonsterRace>(tmp);
                Game.PlaceMonsterAux(mPtr.MapY, mPtr.MapX, race, false, false, charm);
                mPtr = Game.Monsters[cPtr.MonsterIndex];
            }
        }
        else if (doConf != 0 && !rPtr.ImmuneConfusion && !rPtr.BreatheConfusion && !rPtr.BreatheChaos)
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
