namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceMageCharacterClassRacialPower : RacialPower
{
    private DraconianRaceMageCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceManaOrDisenchantmentCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(MageCharacterClass);
}