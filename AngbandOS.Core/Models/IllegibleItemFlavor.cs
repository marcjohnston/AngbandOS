// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class IllegibleItemFlavor : Flavor
{
    public override Symbol Symbol { get; protected set; }
    public override ColorEnum Color { get; }
    public override string Name { get; }
    public override GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Symbol), saveGameState.CreateGameStateBag(Symbol)),
            (nameof(Color), saveGameState.CreateGameStateBag(Color)),
            (nameof(Name), saveGameState.CreateGameStateBag(Name))
        );
    }

    public IllegibleItemFlavor(Game game, RestoreGameState restoreGameState) : this(game, restoreGameState.GetByKey(nameof(Symbol)).GetReference<Symbol>(), restoreGameState.GetByKey(nameof(Color)).GetEnum<ColorEnum>(), restoreGameState.GetByKey(nameof(Name)).GetString())
    {
    }

    public IllegibleItemFlavor(Game game, Symbol symbol, ColorEnum color, string name) : base(game)
    {
        Symbol = symbol;
        Color = color;
        Name = name;
    }
}
