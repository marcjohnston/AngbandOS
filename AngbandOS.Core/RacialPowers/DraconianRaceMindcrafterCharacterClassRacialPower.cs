namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceMindcrafterCharacterClassRacialPower : RacialPower
{
    private DraconianRaceMindcrafterCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceConfusionOrPsiCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(MindcrafterCharacterClass);
}