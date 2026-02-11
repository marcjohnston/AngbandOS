namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class MindcrafterCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MindcrafterCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(SmallSwordWeaponItemFactory), null),
            (nameof(RestoreManaPotionItemFactory), null),
            (nameof(SoftLeatherSoftArmorItemFactory), null)
        };
    }
}