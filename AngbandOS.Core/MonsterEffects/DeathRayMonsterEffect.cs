// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class DeathRayMonsterEffect : MonsterEffect
{
    private DeathRayMonsterEffect(Game game) : base(game) { } // This object is a singleton.

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
        if (rPtr.Undead || rPtr.Nonliving)
        {
            if (rPtr.Undead)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.Undead = true;
                }
            }
            note = " is immune.";
            obvious = false;
            dam = 0;
        }
        else if ((rPtr.Unique && Game.DieRoll(888) != 666) || (rPtr.Level + Game.DieRoll(20) > Game.DieRoll(dam + Game.DieRoll(10)) && Game.DieRoll(100) != 66))
        {
            note = " resists!";
            obvious = false;
            dam = 0;
        }
        else
        {
            dam = Game.ExperienceLevel.IntValue * 200;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious;
    }
}
