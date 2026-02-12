namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DruidCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string?, bool)? CharacterClassBindingKey => (nameof(CharacterClassesEnum.DruidCharacterClass), true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(QuarterstaffHaftedWeaponItemFactory), null, "1", true, true),
            (nameof(SustainWisdomRingItemFactory), null, "1", true, true),
        };
    }
}