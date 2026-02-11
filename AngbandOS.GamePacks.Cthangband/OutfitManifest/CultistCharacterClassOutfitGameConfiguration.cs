namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class CultistCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.CultistCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(SustainIntelligenceRingItemFactory), null),
        };
    }
}