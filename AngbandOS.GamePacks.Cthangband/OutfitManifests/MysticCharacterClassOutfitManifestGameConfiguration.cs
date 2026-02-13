namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class MysticCharacterClassOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.MysticCharacterClass) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SustainWisdomRingItemFactory), null, "1", true, true),
            (nameof(HealingPotionItemFactory), null, "1", true, true),
            (nameof(SoftLeatherSoftArmorItemFactory), null, "1", true, true)
        };
    }
}