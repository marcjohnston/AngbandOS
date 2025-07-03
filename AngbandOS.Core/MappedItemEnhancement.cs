namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MappedItemEnhancement : IGetKey, IToJson
{
    protected readonly Game Game;
    public MappedItemEnhancement(Game game, MappedItemEnhancementGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.Key ?? gameConfiguration.GetType().Name;
        FixedArtifactBindingKeys = gameConfiguration.FixedArtifactBindingKeys;
        CharacterClassBindingKeys = gameConfiguration.CharacterClassBindingKeys;
        ItemEnhancementBindingKeys = gameConfiguration.ItemEnhancementBindingKeys;
    }

    public string Key { get; }
    public string GetKey => Key;

    public void Bind()
    {
        ItemEnhancements = Game.SingletonRepository.GetNullable<IItemEnhancement>(ItemEnhancementBindingKeys);
    }
    public string ToJson()
    {
        MappedItemEnhancementGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            FixedArtifactBindingKeys = FixedArtifactBindingKeys,
            CharacterClassBindingKeys = CharacterClassBindingKeys,
            ItemEnhancementBindingKeys = ItemEnhancementBindingKeys
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public virtual string[]? FixedArtifactBindingKeys { get; }
    public virtual string[]? CharacterClassBindingKeys { get; }
    protected virtual string[]? ItemEnhancementBindingKeys { get; }
    public IItemEnhancement[]? ItemEnhancements { get; private set; }
}
