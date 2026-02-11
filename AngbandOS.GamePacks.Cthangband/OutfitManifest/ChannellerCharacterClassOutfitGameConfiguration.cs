namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChannellerCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.ChannelerCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(MagicMissileWandItemFactory), null),
            (nameof(DaggerWeaponItemFactory), null),
            (nameof(SustainCharismaRingItemFactory), null)
        };
    }

}