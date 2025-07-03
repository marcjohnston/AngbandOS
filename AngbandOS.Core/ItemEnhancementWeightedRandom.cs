// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a singleton for a weighted random of nullable <see cref="ItemEnhancement"/> objects.  This weighted random supports null to allow a non-selection.
/// </summary>
[Serializable]
internal class ItemEnhancementWeightedRandom : WeightedRandom<ItemEnhancement?>, IGetKey, IToJson, IItemEnhancement
{
    public ItemEnhancementWeightedRandom(Game game, ItemEnhancementWeightedRandomGameConfiguration itemEnhancementWeightedRandomGameConfiguration) : base(game)
    {
        Key = itemEnhancementWeightedRandomGameConfiguration.Key ?? itemEnhancementWeightedRandomGameConfiguration.GetType().Name;
        NameAndWeightBindings = itemEnhancementWeightedRandomGameConfiguration.NameAndWeightBindings;
    }

    /// <summary>
    /// Returns the nullable names and weights.  Names can be null to support non-action weights.
    /// </summary>
    protected (string? name, int weight)[] NameAndWeightBindings { get; }

    /// <summary>
    /// Chooses one of the available <see cref="ItemEnhancement"/> items and returns it.  This allows this <see cref="ItemEnhancementWeightedRandom"/> to be used in the <see cref="MappedItemEnhancement.ItemEnhancements"/>.
    /// </summary>
    /// <returns></returns>
    public ItemEnhancement? GetItemEnhancement() => Choose();

    public virtual string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        foreach ((string? name, int weight) in NameAndWeightBindings)
        {
            Add(weight, name == null ? null : Game.SingletonRepository.Get<ItemEnhancement>(name)); // TODO: This smells because of the nullability
        }
    }

    public string ToJson()
    {
        ItemEnhancementWeightedRandomGameConfiguration definition = new ItemEnhancementWeightedRandomGameConfiguration()
        {
            Key = Key,
            NameAndWeightBindings = NameAndWeightBindings,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
}
