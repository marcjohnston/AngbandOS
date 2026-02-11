namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class NatureRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(NatureRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(CallOfTheWildNatureBookItemFactory), null),
        };
    }

}