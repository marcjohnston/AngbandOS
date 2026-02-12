namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class NatureRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(NatureRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(CallOfTheWildNatureBookItemFactory), null, "1", true, false),
        };
    }

}