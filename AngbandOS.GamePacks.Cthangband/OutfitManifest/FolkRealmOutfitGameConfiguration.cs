namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FolkRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? RealmBindingKey => nameof(FolkRealm);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(CantripsForBeginnersFolkBookItemFactory), null, "1", true, false),
        };
    }

}