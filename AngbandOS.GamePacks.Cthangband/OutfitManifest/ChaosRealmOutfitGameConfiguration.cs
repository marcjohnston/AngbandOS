namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChaosRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? RealmBindingKey => (new string[] { nameof(ChaosRealm) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SignOfChaosChaosBookItemFactory), null, "1", true, false),
        };
    }
}