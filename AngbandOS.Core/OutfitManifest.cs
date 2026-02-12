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
    
    public (string? MatchValue, bool IsEqual)? CharacterClassBindingKey { get; private set; }
    public (string? MatchValue, bool IsEqual)? RaceBindingKey { get; private set; }
    public (string? MatchValue, bool IsEqual)? RealmBindingKey { get; private set; }
    private (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKeys, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings { get; set; }
    public (ItemFactory, ItemEnhancement[]?, Expression, bool, bool)[] ItemFactoryAndEnhancements { get; private set; }
    public string GetKey => Game.GetCompositeKey(CharacterClassBindingKey, RaceBindingKey, RealmBindingKey);

    public void Bind()
    {
        // Validate.
        //if (CharacterClassBindingKey.MatchValue == null && CharacterClassBindingKey.Equal)
        //{
        //    throw new Exception($"The CharacterClassBindingKey {nameof(OutfitManifest)} with key {GetKey} has a null match value and equal set to true, which is not valid because the player character classes will never be null.");
        //}
        //if (RaceBindingKey.MatchValue == null && RaceBindingKey.Equal)
        //{
        //    throw new Exception($"The RaceBindingKey {nameof(OutfitManifest)} with key {GetKey} has a null match value and equal set to true, which is not valid because the player reace will never be null.");
        //}

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
