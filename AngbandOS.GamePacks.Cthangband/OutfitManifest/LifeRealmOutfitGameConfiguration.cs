namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class LifeRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(LifeRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(CommonPrayerLifeBookItemFactory), null),
        };
    }

}