namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DeathRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(DeathRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(BlackPrayersDeathBookItemFactory), null),
        };
    }

}