namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class CorporealRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? RealmBindingKey => (new string[] { nameof(CorporealRealm) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(BasicChiFlowCorporealBookItemFactory), null, "1", true, false),
        };
    }

}