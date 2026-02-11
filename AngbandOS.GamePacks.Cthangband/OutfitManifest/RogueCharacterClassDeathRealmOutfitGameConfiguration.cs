namespace AngbandOS.GamePacks.Cthangband
{
    public class RogueCharacterClassDeathRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
        public override string? RealmBindingKey => nameof(DeathRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(DaggerWeaponItemFactory), new string[] { nameof(WeaponOfPoisoningItemEnhancement) }),
        };
    }
}