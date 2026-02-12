namespace AngbandOS.GamePacks.Cthangband
{
    public class RogueCharacterClassSorceryRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
        public override string? RealmBindingKey => nameof(SorceryRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(DaggerWeaponItemFactory), null, "1", true, true),
        };
    }
}