// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterFilters;

[Serializable]
internal class Bizarre5MonsterFilter : MonsterFilter
{
    private Bizarre5MonsterFilter(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override bool Matches(MonsterRace rPtr)
    {
        return rPtr.Symbol.Character == '$' && !rPtr.Unique;
    }
}
