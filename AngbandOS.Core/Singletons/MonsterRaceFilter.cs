// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal abstract class MonsterRaceFilter : IMonsterSelector, IGetKey, IGameSerialize
{
    protected Game Game { get; }

    protected MonsterRaceFilter(Game game)
    {
        Game = game;
    }
    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public virtual GameStateBag? Serialize(SaveGameState saveGameState) => null;

    public void Bind(RestoreGameState? restoreGameState)
    {
        AnySymbol = Game.SingletonRepository.GetNullable<Symbol>(AnySymbolBindingKeys);
        AnyMonsterRace = Game.SingletonRepository.GetNullable<MonsterRace>(AnyMonsterRaceBindingKeys);
        AnyMonsterSpell = Game.SingletonRepository.GetNullable<MonsterSpell>(AnyMonsterSpellBindingKeys);
    }

    public MonsterRaceFilter GetMonsterFilter(MonsterRace monsterRace) => this;

    public virtual string[]? AnySymbolBindingKeys => null;
    public virtual string[]? AnyMonsterRaceBindingKeys => null;
    public virtual string[]? AnyMonsterSpellBindingKeys => null;

    protected Symbol[]? AnySymbol { get; private set; } = null;
    protected MonsterSpell[]? AnyMonsterSpell { get; private set; } = null;

    protected MonsterRace[]? AnyMonsterRace { get; private set; } = null;
    /// <summary>
    /// Returns true, if a monster matches the selector.  Returns true, by default, matching all monster races.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="rPtr">The monster race to check.</param>
    /// <returns></returns>
    public virtual bool Matches(MonsterRace rPtr)
    {
        if (AnySymbol is not null && !AnySymbol.Contains(rPtr.Symbol))
        {
            return false;
        }
        if (AnyMonsterRace is not null && !AnyMonsterRace.Contains(rPtr))
        {
            return false;
        }
        if (AnyMonsterSpell is not null && !rPtr.Spells.Any(_monsterSpell => AnyMonsterSpell.Contains(_monsterSpell)))
        {
            return false;
        }
        return true;
    }
}

