namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class MageCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(DaggerWeaponItemFactory), null),
        };
    }
}