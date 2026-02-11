namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SorceryRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(SorceryRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(BeginnersHandbookSorceryBookItemFactory), null),
        };
    }

}