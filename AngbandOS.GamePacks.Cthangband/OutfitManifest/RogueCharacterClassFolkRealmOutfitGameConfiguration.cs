namespace AngbandOS.GamePacks.Cthangband
{
    public class RogueCharacterClassFolkRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
        public override string? RealmBindingKey => nameof(FolkRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(DaggerWeaponItemFactory), null),
        };
    }
}