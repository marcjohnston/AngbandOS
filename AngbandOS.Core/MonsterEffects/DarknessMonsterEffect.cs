﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class DarknessMonsterEffect : MonsterEffect
{
    private DarknessMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the null if the monster is visible because invisible pets do not become unfriendly when hit with darkness.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(VisibleMonsterFilter);

    protected override IdentifiedResultEnum Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;

        if (seen)
        {
            obvious = true;
        }
        if (rPtr.BreatheDark || rPtr.Orc || rPtr.HurtByLight)
        {
            note = " resists.";
            dam *= 2;
            dam /= Game.DieRoll(6) + 6;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
