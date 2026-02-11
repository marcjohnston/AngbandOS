namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FolkRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(FolkRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(CantripsForBeginnersFolkBookItemFactory), null),
        };
    }

}