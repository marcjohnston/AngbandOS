namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RangerCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(CallOfTheWildNatureBookItemFactory), null),
            (nameof(BroadSwordWeaponItemFactory), null),
            (nameof(BlackPrayersDeathBookItemFactory), null)
        };
    }
}