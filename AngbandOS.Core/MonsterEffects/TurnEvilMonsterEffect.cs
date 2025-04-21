// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class TurnEvilMonsterEffect : MonsterEffect
{
    private TurnEvilMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="EvilMonsterFilter"/> because evil pets will become unfriendly when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(EvilMonsterFilter);

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        bool skipped = false;
        int doFear = 0;
        string? note = null;
        if (rPtr.Evil)
        {
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Evil = true;
            }
            if (seen)
            {
                obvious = true;
            }
            doFear = Game.DiceRoll(3, dam / 2) + 1;
            if (rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
            {
                note = " is unaffected!";
                obvious = false;
                doFear = 0;
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
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, doFear);
        return obvious;
    }
}
