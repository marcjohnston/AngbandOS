namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FolkRealmOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? RealmBindingKey => (new string[] { nameof(FolkRealm) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(CantripsForBeginnersFolkBookItemFactory), null, "1", true, false),
        };
    }

}