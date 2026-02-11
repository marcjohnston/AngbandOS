namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class HighMageClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(DaggerWeaponItemFactory), null),
            (nameof(SustainIntelligenceRingItemFactory), null),
        };
    }
}