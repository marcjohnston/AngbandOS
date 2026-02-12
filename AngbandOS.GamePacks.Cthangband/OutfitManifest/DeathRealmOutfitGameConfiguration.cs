namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DeathRealmOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? RealmBindingKey => (new string[] { nameof(DeathRealm) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(BlackPrayersDeathBookItemFactory), null, "1", true, false),
        };
    }

}