// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ActivationReadOnlyAttributeValue : AttributeValue, IGameSerialize
{
    public readonly Activation? Value;
    public ActivationReadOnlyAttributeValue(Activation? value)
    {
        Value = value;
    }
    public ActivationReadOnlyAttributeValue(Game game, RestoreGameState restoreGameState) : this(restoreGameState.GetReferenceOrDefault<Activation>(nameof(Value)))
    {
    }

    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Value), saveGameState.CreateGameStateBag(Value))
        );
    }
}
