namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class CorporealRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(CorporealRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(BasicChiFlowCorporealBookItemFactory), null),
        };
    }

}