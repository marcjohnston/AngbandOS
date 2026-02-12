namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class CharacterClassThatCanEatOutfitGameConfiguration : OutfitManifestGameConfiguration
    {
        public override (string[]?, bool)? RaceBindingKey => (new string[] { nameof(RacesEnum.GolemRace), nameof(RacesEnum.SkeletonRace), nameof(RacesEnum.SpectreRace), nameof(RacesEnum.VampireRace), nameof(RacesEnum.ZombieRace) }, false);
        public override (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings => new (string, string[]?, string, bool, bool)[]
        {
            (nameof(RationFoodItemFactory), null, "1d5+2", true, false),
        };
    }
}