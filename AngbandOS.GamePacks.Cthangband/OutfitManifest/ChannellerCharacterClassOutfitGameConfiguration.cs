namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChannellerCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string?, bool)? CharacterClassBindingKey => (nameof(CharacterClassesEnum.ChannelerCharacterClass), true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(MagicMissileWandItemFactory), null, "1", true, false),
            (nameof(DaggerWeaponItemFactory), null, "1", true, true),
            (nameof(SustainCharismaRingItemFactory), null, "1", true, true)
        };
    }
}