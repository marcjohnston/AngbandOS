namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class MageCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.MageCharacterClass) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(DaggerWeaponItemFactory), null, "1", true, true),
        };
    }
}