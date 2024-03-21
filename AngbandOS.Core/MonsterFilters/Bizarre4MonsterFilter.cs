// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterFilters;

[Serializable]
internal class Bizarre4MonsterFilter : MonsterFilter
{
    private Bizarre4MonsterFilter(Game game) : base(game) { } // This object is a singleton.
    public override bool Matches(MonsterRace rPtr)
    {
        return rPtr.Symbol.Character == 'v' && !rPtr.Unique;
    }
}
