﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class WaterMonsterEffect : MonsterEffect
{
    private WaterMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    protected override IdentifiedResultEnum Apply(int who, Monster mPtr, int dam, int r)
    {
        bool obvious = false;
        string? note = null;
        MonsterRace rPtr = mPtr.Race;
        string name = rPtr.FriendlyName;
        bool seen = mPtr.IsVisible;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.Symbol.Character == 'E' && (name.StartsWith("W") || rPtr.FriendlyName.Contains("Unmaker")))
        {
            note = " is immune.";
            dam = 0;
        }
        else if (rPtr.ResistWater)
        {
            note = " resists.";
            dam *= 3;
            dam /= Game.DieRoll(6) + 6;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ResistWater = true;
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
