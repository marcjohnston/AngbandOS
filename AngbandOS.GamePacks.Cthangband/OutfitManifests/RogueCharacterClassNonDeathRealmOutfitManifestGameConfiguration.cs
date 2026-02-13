namespace AngbandOS.GamePacks.Cthangband
{
    public class RogueCharacterClassNonDeathRealmOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.RogueCharacterClass) }, true);
        public override (string[], bool)? RealmBindingKey => (new string[] { nameof(DeathRealm) }, false);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(DaggerWeaponItemFactory), null, "1", true, true),
        };
    }
}