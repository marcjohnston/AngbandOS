namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PriestCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.PriestCharacterClass);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(MaceHaftedWeaponItemFactory), null, "1", true, true),
        };
    }
}