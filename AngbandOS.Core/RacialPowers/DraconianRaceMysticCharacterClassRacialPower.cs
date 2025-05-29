namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceMysticCharacterClassRacialPower : RacialPower
{
    private DraconianRaceMysticCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceConfusionOrPsiCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(MysticCharacterClass);
}