namespace AngbandOS.GamePacks.Cthangband
{
    public class RogueCharacterClassDeathRealmOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.RogueCharacterClass) }, true);
        public override (string[], bool)? RealmBindingKey => (new string[] { nameof(DeathRealm) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(DaggerWeaponItemFactory), new string[] { nameof(WeaponOfPoisoningItemEnhancement) }, "1", true, true),
        };
    }
}