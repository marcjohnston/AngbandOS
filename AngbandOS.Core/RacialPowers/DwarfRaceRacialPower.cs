namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DwarfRaceRacialPower : RacialPower
{
    private DwarfRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DwarfRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DwarfRace);
}