// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal class OldSlowAffectMonsterScript : AffectMonsterScript
{
    private OldSlowAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

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
        if (rPtr.Unique ||
            rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            note = " is unaffected!";
            obvious = false;
        }
        else
        {
            if (mPtr.Speed > 60)
            {
                mPtr.Speed -= 10;
            }
            note = " starts moving slower.";
        }
        dam = 0;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }
}
