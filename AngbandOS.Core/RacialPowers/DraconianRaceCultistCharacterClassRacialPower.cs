namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceCultistCharacterClassRacialPower : RacialPower
{
    private DraconianRaceCultistCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceConfusionOrChaosRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(CultistCharacterClass);
}