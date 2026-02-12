namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WarriorCharacterClassHalfOgreRaceOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
        public override string? RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(FearResistanceRingItemFactory), null, "1", true, true),
        };
    }
}