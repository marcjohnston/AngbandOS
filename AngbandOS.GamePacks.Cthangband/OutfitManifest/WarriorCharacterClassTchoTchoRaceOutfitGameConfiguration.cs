namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WarriorCharacterClassTchoTchoRaceOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? CharacterClassBindingKey => (new string[] { nameof(CharacterClassesEnum.WarriorCharacterClass) }, true);
        public override (string[]?, bool)? RaceBindingKey => (new string[] { nameof(RacesEnum.TchoTchoRace) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(SustainStrengthRingItemFactory), null, "1", true, true),
        };
    }
}