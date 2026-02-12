namespace AngbandOS.GamePacks.Cthangband
{
    public class RogueCharacterClassNonDeathRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string?, bool)? CharacterClassBindingKey => (nameof(CharacterClassesEnum.RogueCharacterClass), true);
        public override (string?, bool)? RealmBindingKey => (nameof(DeathRealm), false);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(DaggerWeaponItemFactory), null, "1", true, true),
        };
    }
}