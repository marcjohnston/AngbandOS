namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceWarriorMageCharacterClassRacialPower : RacialPower
{
    private DraconianRaceWarriorMageCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceManaOrDisenchantmentCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(WarriorMageCharacterClass);
}