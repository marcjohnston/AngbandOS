namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FanaticCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(BroadSwordWeaponItemFactory), null),
            (nameof(MetalScaleMailHardArmorItemFactory), null),
        };
    }
}