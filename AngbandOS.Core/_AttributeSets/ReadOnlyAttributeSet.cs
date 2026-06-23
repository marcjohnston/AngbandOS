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
    public ReadOnlyAttributeSet(Game game, RestoreGameState restoreGameState) : this(game, restoreGameState.GetByKey(nameof(Value)).GetDerivedReferences<AttributeValue>(
        (RestoreGameState restoreGameState) => new ActivationReadOnlyAttributeValue(game, restoreGameState), 
        (RestoreGameState restoreGameState) => new ArtifactBiasReadOnlyAttributeValue(game, restoreGameState), 
        (RestoreGameState restoreGameState) => new BoolReadOnlyAttributeValue(game, restoreGameState), 
        (RestoreGameState restoreGameState) => new IntReadOnlyAttributeValue(game, restoreGameState), 
        (RestoreGameState restoreGameState) => new NullableBoolReadOnlyAttributeValue(game, restoreGameState), 
        (RestoreGameState restoreGameState) => new NullableStringReadOnlyAttributeValue(game, restoreGameState)
        ))
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

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Value), saveGameState.CreateDerivedGameStateBag(Value, typeof(ActivationReadOnlyAttributeValue), typeof(ArtifactBiasReadOnlyAttributeValue), typeof(BoolReadOnlyAttributeValue), typeof(IntReadOnlyAttributeValue), typeof(NullableBoolReadOnlyAttributeValue), typeof(NullableStringReadOnlyAttributeValue)))
        );
    }
}
