namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TarotRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(TarotRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(ConjuringsTricksTarotBookItemFactory), null, "1", true, false),
        };
    }

}