namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RogueCharacterClassOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.RogueCharacterClass) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SoftLeatherSoftArmorItemFactory), null, "1", true, true),
        };
    }
}