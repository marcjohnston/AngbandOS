namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class MysticCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MysticCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(SustainWisdomRingItemFactory), null),
            (nameof(HealingPotionItemFactory), null),
            (nameof(SoftLeatherSoftArmorItemFactory), null)
        };
    }
}