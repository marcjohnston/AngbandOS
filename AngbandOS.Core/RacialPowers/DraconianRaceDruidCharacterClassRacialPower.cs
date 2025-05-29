namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceDruidCharacterClassRacialPower : RacialPower
{
    private DraconianRaceDruidCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceMissileOrExpolodeCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(DruidCharacterClass);
}