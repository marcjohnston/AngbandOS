namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WarriorCharacterClassNonTchoTchoRaceOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string?, bool)? CharacterClassBindingKey => (nameof(CharacterClassesEnum.WarriorCharacterClass), true);
        public override (string?, bool)? RaceBindingKey => (nameof(RacesEnum.TchoTchoRace), false);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new(string, string[]?, string, bool, bool)[]
        {
            (nameof(FearResistanceRingItemFactory), null, "1", true, true),
        };
    }
}