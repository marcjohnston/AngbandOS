using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal sealed class MappedItemEnhancement : IGetKey, IToJson, IGameSerialize
{
    private Game Game { get; }
    public MappedItemEnhancement(Game game, MappedItemEnhancementGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        FixedArtifactBindingKeys = gameConfiguration.FixedArtifactBindingKeys;
        CharacterClassBindingKeys = gameConfiguration.CharacterClassBindingKeys;
        ItemEnhancementBindingKeys = gameConfiguration.ItemEnhancementBindingKeys;
    }

    public DictionaryGameStateBag? Serialize(SaveGameState saveGameState) => null;
    public string Key { get; }
    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState)
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
    public string[]? FixedArtifactBindingKeys { get; }
    public string[]? CharacterClassBindingKeys { get; }
    private string[]? ItemEnhancementBindingKeys { get; }
    public IItemEnhancement[]? ItemEnhancements { get; private set; }
}
