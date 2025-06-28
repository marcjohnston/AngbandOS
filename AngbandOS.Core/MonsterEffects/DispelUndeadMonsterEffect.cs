// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class DispelUndeadMonsterEffect : MonsterEffect
{
    private DispelUndeadMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="UndeadMonsterFilter"/> because undead pets will become unfriendly when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(UndeadMonsterFilter);

    protected override IdentifiedResultEnum Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        bool skipped = false;
        string? note = null;
        string? noteDies = null;
        if (rPtr.Undead)
        {
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Undead = true;
            }
            if (seen)
            {
                obvious = true;
            }
            note = " shudders.";
            noteDies = " dissolves!";
        }
        else
        {
            skipped = true;
            dam = 0;
        }
        if (skipped)
        {
            return IdentifiedResultEnum.False;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies, 0);
        return obvious ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
