namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HalfOgreRaceWarriorCharacterClassRacialPower : RacialPower
{
    private HalfOgreRaceWarriorCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HalfOgreRaceWarriorCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HalfOgreRace);
    protected override string? CharacterClassBindingKey => nameof(WarriorCharacterClass);
}