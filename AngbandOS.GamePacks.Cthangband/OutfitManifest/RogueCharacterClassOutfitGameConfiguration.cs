namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RogueCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(SoftLeatherSoftArmorItemFactory), null),
        };
    }
}