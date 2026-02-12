namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChaosRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(ChaosRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SignOfChaosChaosBookItemFactory), null, "1", true, false),
        };
    }
}