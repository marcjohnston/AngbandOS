namespace AngbandOS.GamePacks.Cthangband
{
    public class RogueCharacterClassNatureRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
        public override string? RealmBindingKey => nameof(NatureRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(DaggerWeaponItemFactory), null),
        };
    }
}