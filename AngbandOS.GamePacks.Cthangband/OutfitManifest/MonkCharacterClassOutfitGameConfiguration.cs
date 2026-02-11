namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class MonkCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MonkCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(HealingPotionItemFactory), null),
            (nameof(SoftLeatherSoftArmorItemFactory), null),
        };
    }
}