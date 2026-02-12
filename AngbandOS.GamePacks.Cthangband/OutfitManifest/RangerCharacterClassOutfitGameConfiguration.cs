namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RangerCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(BroadSwordWeaponItemFactory), null, "1", true, true),
        };
    }
}