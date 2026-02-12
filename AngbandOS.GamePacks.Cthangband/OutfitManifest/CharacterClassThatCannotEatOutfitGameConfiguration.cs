namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class CharacterClassThatCannotEatOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? RaceBindingKey => (new string[] { nameof(RacesEnum.GolemRace), nameof(RacesEnum.SkeletonRace), nameof(RacesEnum.SpectreRace), nameof(RacesEnum.VampireRace), nameof(RacesEnum.ZombieRace) }, true);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?, string, bool, bool)[]
        {
            (nameof(SatisfyHungerScrollItemFactory), null, "1d4+1", true, false),
        };
    }
}