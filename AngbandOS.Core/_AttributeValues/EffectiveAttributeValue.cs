// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an effective attribute value with derived classes that implement various algorithms for combining multiple modifiers into a single effective value.
/// </summary>
[Serializable]
internal abstract class EffectiveAttributeValue : AttributeValue
{
    protected readonly Game Game;
    protected readonly Attribute Attribute;
    public EffectiveAttributeValue(Game game, Attribute attribute)
    {
        Game = game;
        Attribute = attribute;
    }
    public abstract string RenderForItemIdentification { get; }
    public abstract EffectiveAttributeValue Clone();

    public abstract AttributeValue ToReadOnly();
    public abstract void Merge(AttributeValue value);
    public abstract void Merge(string key, AttributeValue value);

    public abstract bool HasKeyedItemEnhancements(string key);

    /// <summary>
    /// Removes all modifiers associated with the specified key.
    /// </summary>
    /// <param name="key"></param>
    public abstract void RemoveModifiers(string key);
}
