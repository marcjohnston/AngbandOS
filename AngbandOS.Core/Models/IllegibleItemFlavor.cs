// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class IllegibleItemFlavor : Flavor, IGameSerialize
{
    public override Symbol Symbol { get; protected set; }
    public override ColorEnum Color { get; }
    public override string Name { get; }
    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Name), saveGameState.CreateGameStateBag(Name)),
            (nameof(Symbol), saveGameState.CreateGameStateBag(Symbol)),
            (nameof(Color), saveGameState.CreateGameStateBag(Color))
        );
    }

    public IllegibleItemFlavor(Game game, RestoreGameState restoreGameState) : this(game, restoreGameState.GetReference<Symbol>(nameof(Symbol)), restoreGameState.GetEnum<ColorEnum>(nameof(Color)), restoreGameState.GetString(nameof(Name)))
    {
    }

    public IllegibleItemFlavor(Game game, Symbol symbol, ColorEnum color, string name) : base(game)
    {
        Symbol = symbol;
        Color = color;
        Name = name;
    }
}
