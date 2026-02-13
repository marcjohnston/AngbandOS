namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class NatureRealmOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? RealmBindingKey => (new string[] { nameof(NatureRealm) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(CallOfTheWildNatureBookItemFactory), null, "1", true, false),
        };
    }

}