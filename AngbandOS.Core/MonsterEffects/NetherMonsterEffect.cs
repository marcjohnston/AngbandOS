// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class NetherAffectMonsterScript : AffectMonsterScript
{
    private NetherAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

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
        if (rPtr.Undead)
        {
            note = " is immune.";
            dam = 0;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Undead = true;
            }
        }
        else if (rPtr.ResistNether)
        {
            note = " resists.";
            dam *= 3;
            dam /= Game.DieRoll(6) + 6;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ResistNether = true;
            }
        }
        else if (rPtr.Evil)
        {
            dam /= 2;
            note = " resists somewhat.";
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Evil = true;
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious;
    }
}
