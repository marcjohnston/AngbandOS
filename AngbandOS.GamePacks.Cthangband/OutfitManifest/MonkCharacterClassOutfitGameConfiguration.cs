namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class MonkCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string?, bool)? CharacterClassBindingKey => (nameof(CharacterClassesEnum.MonkCharacterClass), true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(HealingPotionItemFactory), null, "1", true, true),
            (nameof(SoftLeatherSoftArmorItemFactory), null, "1", true, true),
        };
    }
}