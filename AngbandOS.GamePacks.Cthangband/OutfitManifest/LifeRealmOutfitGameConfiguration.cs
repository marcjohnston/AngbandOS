namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class LifeRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(LifeRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(CommonPrayerLifeBookItemFactory), null, "1", true, false),
        };
    }

}