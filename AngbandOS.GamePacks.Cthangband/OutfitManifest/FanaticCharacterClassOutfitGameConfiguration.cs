namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FanaticCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(BroadSwordWeaponItemFactory), null, "1", true, true),
            (nameof(MetalScaleMailHardArmorItemFactory), null, "1", true, true),
        };
    }
}