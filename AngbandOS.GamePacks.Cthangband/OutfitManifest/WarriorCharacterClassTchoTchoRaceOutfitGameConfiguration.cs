namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WarriorCharacterClassTchoTchoRaceOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
        public override string? RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SustainStrengthRingItemFactory), null, "1", true, true),
        };
    }
}