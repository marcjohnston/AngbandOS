namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceRogueCharacterClassRacialPower : RacialPower
{
    private DraconianRaceRogueCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceDarknessOrPoisonCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(RogueCharacterClass);
}