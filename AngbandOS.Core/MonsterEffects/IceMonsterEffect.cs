// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class IceMonsterEffect : MonsterEffect
{
    private IceMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        if (seen)
        {
            obvious = true;
        }
        int doStun = (Game.DieRoll(15) + 1) / (r + 1);
        if (rPtr.ImmuneCold)
        {
            note = " resists a lot.";
            dam /= 9;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ImmuneCold = true;
            }
        }
        if (doStun != 0 && !rPtr.BreatheSound && !rPtr.BreatheForce)
        {
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
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious;
    }
}
