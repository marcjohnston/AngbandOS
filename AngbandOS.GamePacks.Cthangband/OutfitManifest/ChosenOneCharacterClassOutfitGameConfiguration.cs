namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChosenOneCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.ChosenOneCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(SmallSwordWeaponItemFactory), null),
            (nameof(HealingPotionItemFactory), null),
            (nameof(SoftLeatherSoftArmorItemFactory), null)
        };
    }
}