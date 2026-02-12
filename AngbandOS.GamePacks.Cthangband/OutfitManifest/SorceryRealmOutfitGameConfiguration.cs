namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SorceryRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(SorceryRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(BeginnersHandbookSorceryBookItemFactory), null, "1", true, false),
        };
    }

}