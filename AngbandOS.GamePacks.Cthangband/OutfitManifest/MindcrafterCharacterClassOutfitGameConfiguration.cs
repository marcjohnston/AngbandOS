namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class MindcrafterCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MindcrafterCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SmallSwordWeaponItemFactory), null, "1", true, true),
            (nameof(RestoreManaPotionItemFactory), null, "1", true, true),
            (nameof(SoftLeatherSoftArmorItemFactory), null, "1", true, true)
        };
    }
}