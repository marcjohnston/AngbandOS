namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TarotRealmOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? RealmBindingKey => (new string[] { nameof(TarotRealm) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(ConjuringsTricksTarotBookItemFactory), null, "1", true, false),
        };
    }

}