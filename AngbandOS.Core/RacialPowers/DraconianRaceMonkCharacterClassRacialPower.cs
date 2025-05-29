namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceMonkCharacterClassRacialPower : RacialPower
{
    private DraconianRaceMonkCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceConfusionOrSoundCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(MonkCharacterClass);
}