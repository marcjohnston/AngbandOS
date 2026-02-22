// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class ReadOnlyAttributeSet
{
    private readonly Game Game;
    public AttributeValue[] Value { get; }
    public ReadOnlyAttributeSet(Game game, AttributeValue[] value)
    {
        Game = game;
        Value = value;
    }
    public AttributeValue this[int index] => Value[(int)index];
    public T Get<T>(string attributeName)
    {
        Attribute attribute = Game.SingletonRepository.Get<Attribute>(attributeName);
        int index = attribute.Index;
        ReadOnlyAttributeValue<T> value = (ReadOnlyAttributeValue<T>)Value[index];
        return value.Value;
    }
}