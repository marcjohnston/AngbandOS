// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class ItemFactoryWeightedRandom : WeightedRandom<ItemFactory>, IGetKey, IToJson
{
    public ItemFactoryWeightedRandom(Game game, ItemFactoryWeightedRandomGameConfiguration itemFactoryWeightedRandomGameConfiguration) : base(game)
    {
        Key = itemFactoryWeightedRandomGameConfiguration.Key ?? itemFactoryWeightedRandomGameConfiguration.GetType().Name;
        NameAndWeightBindings = itemFactoryWeightedRandomGameConfiguration.NameAndWeightBindings;
    }

    /// <summary>
    /// Returns the nullable names and weights.  Names can be null to support non-action weights.
    /// </summary>
    private (string name, int weight)[] NameAndWeightBindings { get; }

    public string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        foreach ((string name, int weight) in NameAndWeightBindings)
        {
            Add(weight, Game.SingletonRepository.Get<ItemFactory>(name));
        }
    }

    public string ToJson()
    {
        ItemFactoryWeightedRandomGameConfiguration definition = new()
        {
            Key = Key,
            NameAndWeightBindings = NameAndWeightBindings,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
}
