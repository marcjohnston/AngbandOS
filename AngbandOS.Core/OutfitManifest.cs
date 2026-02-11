// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class OutfitManifest : IGetKey, IToJson
{
    private readonly Game Game;
    public OutfitManifest(Game game, OutfitManifestGameConfiguration characterClassAndRaceOutfitGameConfiguration)
    {
        Game = game;
        CharacterClassBindingKey = characterClassAndRaceOutfitGameConfiguration.CharacterClassBindingKey;
        RaceBindingKey = characterClassAndRaceOutfitGameConfiguration.RaceBindingKey;
        RealmBindingKey = characterClassAndRaceOutfitGameConfiguration.RealmBindingKey;
        ItemFactoryAndEnhancementsBindings = characterClassAndRaceOutfitGameConfiguration.ItemFactoryAndEnhancementsBindings;
    }
    
    public string? CharacterClassBindingKey { get; private set; }
    public string? RaceBindingKey { get; private set; }
    public string? RealmBindingKey { get; private set; }
    protected (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings { get; private set; }
    public (ItemFactory, ItemEnhancement[]?)[] ItemFactoryAndEnhancements { get; private set; }
    public string GetKey => Game.GetCompositeKey(CharacterClassBindingKey, RaceBindingKey, RealmBindingKey);

    public void Bind()
    {
        List<(ItemFactory, ItemEnhancement[]?)> itemFactoriesAndEnhancementsList = new();
        foreach ((string itemFactoryBindingKey, string[]? itemEnhancementBindingKeys) in ItemFactoryAndEnhancementsBindings)
        {
            ItemFactory itemFactory = Game.SingletonRepository.Get<ItemFactory>(itemFactoryBindingKey);
            ItemEnhancement[]? itemEnhancements = Game.SingletonRepository.GetNullable<ItemEnhancement>(itemEnhancementBindingKeys);
            itemFactoriesAndEnhancementsList.Add((itemFactory, itemEnhancements));
        }
        ItemFactoryAndEnhancements = itemFactoriesAndEnhancementsList.ToArray();
    }

    public string ToJson()
    {
        OutfitManifestGameConfiguration gameConfiguration = new()
        {
            CharacterClassBindingKey = CharacterClassBindingKey,
            RaceBindingKey = RaceBindingKey,
            RealmBindingKey = RealmBindingKey,
            ItemFactoryAndEnhancementsBindings = ItemFactoryAndEnhancementsBindings,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
}
