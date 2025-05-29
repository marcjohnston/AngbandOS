namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceRangerCharacterClassRacialPower : RacialPower
{
    private DraconianRaceRangerCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceMissileOrExpolodeCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(RangerCharacterClass);
}