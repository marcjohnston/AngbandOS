namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TarotRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(TarotRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?)[]
        {
            (nameof(ConjuringsTricksTarotBookItemFactory), null),
        };
    }

}