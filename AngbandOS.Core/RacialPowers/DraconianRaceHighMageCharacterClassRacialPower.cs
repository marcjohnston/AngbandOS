namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceHighMageCharacterClassRacialPower : RacialPower
{
    private DraconianRaceHighMageCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceManaOrDisenchantmentCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(HighMageCharacterClass);
}