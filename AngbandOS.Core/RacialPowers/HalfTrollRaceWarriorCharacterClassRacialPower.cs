namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HalfTrollRaceWarriorCharacterClassRacialPower : RacialPower
{
    private HalfTrollRaceWarriorCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HalfTrollRaceWarriorCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HalfTrollRace);
    protected override string? CharacterClassBindingKey => nameof(WarriorCharacterClass);
}