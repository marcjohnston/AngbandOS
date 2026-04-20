// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class ReadOnlyAttributeSet : IGameSerialize
{
    private Game Game { get; }
    public readonly AttributeValue[] Value;
    public ReadOnlyAttributeSet(Game game, AttributeValue[] value)
    {
        Game = game;
        Value = value;
    }
    public ReadOnlyAttributeSet(Game game, RestoreGameState restoreGameState) : this(game, restoreGameState.GetReferences<AttributeValue>(nameof(Value)))
    {
    }

    public AttributeValue this[int index] => Value[(int)index];
    public int GetInt(string attributeName)
    {
        Attribute attribute = Game.SingletonRepository.Get<Attribute>(attributeName);
        int index = attribute.Index;
        IntReadOnlyAttributeValue value = (IntReadOnlyAttributeValue)Value[index];
        return value.Value;
    }

    public DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Value), saveGameState.CreateGameStateBag(Value))
        );
    }
}
