namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PaladinCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string?, bool)? CharacterClassBindingKey => (nameof(CharacterClassesEnum.PaladinCharacterClass), true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(BroadSwordWeaponItemFactory), null, "1", true, true),
            (nameof(ProtectionFromEvilScrollItemFactory), null, "1", true, true),
        };
    }
}