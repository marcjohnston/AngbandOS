namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WarriorMageCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorMageCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(ShortSwordWeaponItemFactory), null),
        };
    }
}