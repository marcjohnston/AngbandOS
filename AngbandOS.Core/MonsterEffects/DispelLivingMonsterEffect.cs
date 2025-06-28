// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class DispelLivingMonsterEffect : MonsterEffect
{
    private DispelLivingMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="LivingMonsterFilter"/> because living pets will become unfriendly when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(LivingMonsterFilter);

    protected override IdentifiedResultEnum Apply(int who, Monster mPtr, int dam, int r)
    {
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        bool skipped = false;
        string? note = null;
        string? noteDies = null;
        if (!mPtr.Race.Undead && !mPtr.Race.Nonliving)
        {
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
