namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HalfOrcRaceWarriorCharacterClassRacialPower : RacialPower
{
    private HalfOrcRaceWarriorCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HalfOrcRaceWarriorCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HalfOrcRace);
    protected override string? CharacterClassBindingKey => nameof(WarriorCharacterClass);
}