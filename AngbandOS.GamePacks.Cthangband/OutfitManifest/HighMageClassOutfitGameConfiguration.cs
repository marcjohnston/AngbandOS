namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class HighMageClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(DaggerWeaponItemFactory), null, "1", true, true),
            (nameof(SustainIntelligenceRingItemFactory), null, "1", true, true),
        };
    }
}