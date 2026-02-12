namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WarriorCharacterClassOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.WarriorCharacterClass) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(BroadSwordWeaponItemFactory), null, "1", true, true),
            (nameof(ChainMailHardArmorItemFactory), null, "1", true, true)
        };
    }
}