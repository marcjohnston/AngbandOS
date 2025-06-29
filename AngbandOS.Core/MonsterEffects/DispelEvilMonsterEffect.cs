﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class DispelEvilMonsterEffect : MonsterEffect
{
    private DispelEvilMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="EvilMonsterFilter"/> because evil pets will become unfriendly when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(EvilMonsterFilter);

    protected override IdentifiedResultEnum Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        string? note = null;
        string? noteDies = " dissolves!";
        bool obvious = false;
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
            note = " shudders.";
        }
        else
        {
            return IdentifiedResultEnum.False;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies, 0);
        return obvious ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
