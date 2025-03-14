// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class OldSleepMonsterEffect : AffectMonsterScript
{
    private OldSleepMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        int doSleep = 0;
        if (seen)
        {
            obvious = true;
        }
        string note;
        if (rPtr.Unique || rPtr.ImmuneSleep ||
            rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            if (rPtr.ImmuneSleep)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ImmuneSleep = true;
                }
            }
            note = " is unaffected!";
            obvious = false;
        }
        else
        {
            note = " falls asleep!";
            doSleep = 500;
        }
        dam = 0;

        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);

        // Put the monster to sleep, if not dead.
        if (mPtr.Health >= 0 && doSleep != 0)
        {
            mPtr.SleepLevel = doSleep;
        }

        return obvious;
    }
}
