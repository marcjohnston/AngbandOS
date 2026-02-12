namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RogueCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SoftLeatherSoftArmorItemFactory), null, "1", true, true),
        };
    }
}