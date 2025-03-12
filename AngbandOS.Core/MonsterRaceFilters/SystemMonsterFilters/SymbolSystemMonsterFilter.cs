// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class SymbolSystemMonsterFilter : MonsterRaceFilter
{
    private char _character;

    public SymbolSystemMonsterFilter(Game game, char character) : base(game)
    {
        _character = character;
    }

    public override bool Matches(MonsterRace rPtr)
    {
        return rPtr.Symbol.Character == _character && !rPtr.Unique;
    }
}
