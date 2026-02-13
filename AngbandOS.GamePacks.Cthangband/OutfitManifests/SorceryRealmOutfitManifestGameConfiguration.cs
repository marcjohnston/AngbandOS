namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SorceryRealmOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? RealmBindingKey => (new string[] { nameof(SorceryRealm) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(BeginnersHandbookSorceryBookItemFactory), null, "1", true, false),
        };
    }

}