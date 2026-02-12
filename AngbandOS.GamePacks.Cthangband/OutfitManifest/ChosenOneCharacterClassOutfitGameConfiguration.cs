namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChosenOneCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.ChosenOneCharacterClass) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SmallSwordWeaponItemFactory), null, "1", true, true),
            (nameof(HealingPotionItemFactory), null, "1", true, true),
            (nameof(SoftLeatherSoftArmorItemFactory), null, "1", true, true)
        };
    }
}