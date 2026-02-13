namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WarriorMageCharacterClassOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.WarriorMageCharacterClass) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(ShortSwordWeaponItemFactory), null, "1", true, true),
        };
    }
}