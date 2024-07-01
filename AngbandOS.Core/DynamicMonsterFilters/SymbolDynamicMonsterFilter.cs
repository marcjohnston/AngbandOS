// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DynamicMonsterFilters;

[Serializable]
internal class SymbolDynamicMonsterFilter : IMonsterFilter
{
    private readonly Game Game;
    private char _character;

    public SymbolDynamicMonsterFilter(Game game, char character)
    {
        _character = character;
        Game = game;
    }

    public bool Matches(MonsterRace rPtr)
    {
        return rPtr.Symbol.Character == _character && !rPtr.Unique;
    }
}
