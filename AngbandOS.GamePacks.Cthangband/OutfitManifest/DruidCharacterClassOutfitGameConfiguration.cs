namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DruidCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.DruidCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(QuarterstaffHaftedWeaponItemFactory), null),
            (nameof(SustainWisdomRingItemFactory), null),
        };
    }
}