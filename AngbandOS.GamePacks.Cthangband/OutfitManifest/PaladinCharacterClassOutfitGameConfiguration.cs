namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PaladinCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.PaladinCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(BroadSwordWeaponItemFactory), null),
            (nameof(ProtectionFromEvilScrollItemFactory), null),
        };
    }
}