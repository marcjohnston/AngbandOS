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
    
    public (string[]? MatchValues, bool IsEqual)? CharacterClassBindingKey { get; private set; }
    public (string[]? MatchValues, bool IsEqual)? RaceBindingKey { get; private set; }
    public (string[]? MatchValues, bool IsEqual)? RealmBindingKey { get; private set; }
    private (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKeys, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings { get; set; }
    public (ItemFactory, ItemEnhancement[]?, Expression, bool, bool)[] ItemFactoryAndEnhancements { get; private set; }
    public string GetKey => Game.GetCompositeKey(CharacterClassBindingKey, RaceBindingKey, RealmBindingKey);

    public void Bind()
    {
        // Validate.
        if (CharacterClassBindingKey.HasValue && (CharacterClassBindingKey.Value.MatchValues is null || CharacterClassBindingKey.Value.MatchValues.Contains("")))
        {
            throw new Exception($"The {nameof(CharacterClassBindingKey)} {nameof(OutfitManifest)} with key {GetKey} cannot match a null or empty character class value with or without equality.");
        }

        if (RaceBindingKey.HasValue && (RaceBindingKey.Value.MatchValues is null || RaceBindingKey.Value.MatchValues.Contains("")))
        {
            throw new Exception($"The {nameof(RaceBindingKey)} {nameof(OutfitManifest)} with key {GetKey} cannot match a null or empty race value with or without equality.");
        }

        if (RealmBindingKey.HasValue && (RealmBindingKey.Value.MatchValues is null || RealmBindingKey.Value.MatchValues.Contains("")))
        {
            throw new Exception($"The {nameof(RealmBindingKey)} {nameof(OutfitManifest)} with key {GetKey} cannot match a null or empty realm value with or without equality.");
        }

        List<(ItemFactory, ItemEnhancement[]?, Expression, bool, bool)> itemFactoriesAndEnhancementsList = new();
        foreach ((string itemFactoryBindingKey, string[]? itemEnhancementBindingKeys, string stackCountExpression, bool makeKnown, bool wieldOne) in ItemFactoryAndEnhancementsBindings)
        {
            ItemFactory itemFactory = Game.SingletonRepository.Get<ItemFactory>(itemFactoryBindingKey);
            ItemEnhancement[]? itemEnhancements = Game.SingletonRepository.GetNullable<ItemEnhancement>(itemEnhancementBindingKeys);
            Expression stackCount = Game.ParseNumericExpression(stackCountExpression);
            itemFactoriesAndEnhancementsList.Add((itemFactory, itemEnhancements, stackCount, makeKnown, wieldOne));
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
