namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PriestCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.PriestCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(MaceHaftedWeaponItemFactory), null),
        };
    }
}