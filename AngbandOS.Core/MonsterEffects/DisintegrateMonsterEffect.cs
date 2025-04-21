// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class DisintegrateMonsterEffect : MonsterEffect
{
    private DisintegrateMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        string? noteDies = null;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.HurtByRock)
        {
            if (seen)
            {
                rPtr.Knowledge.Characteristics.HurtByRock = true;
            }
            note = " loses some skin!";
            noteDies = " evaporates!";
            dam *= 2;
        }
        if (rPtr.Unique)
        {
            if (Game.RandomLessThan(rPtr.Level + 10) > Game.RandomLessThan(Game.ExperienceLevel.IntValue))
            {
                note = " resists.";
                dam >>= 3;
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies, 0);
        return obvious;
    }
}
