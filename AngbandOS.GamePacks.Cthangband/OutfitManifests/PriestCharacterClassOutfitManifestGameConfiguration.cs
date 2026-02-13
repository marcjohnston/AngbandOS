namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PriestCharacterClassOutfitManifestGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[], bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.PriestCharacterClass) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(MaceHaftedWeaponItemFactory), null, "1", true, true),
        };
    }
}