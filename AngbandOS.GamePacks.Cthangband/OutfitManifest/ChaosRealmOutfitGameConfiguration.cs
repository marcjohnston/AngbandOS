namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChaosRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(ChaosRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(SignOfChaosChaosBookItemFactory), null),
        };
    }

}