namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DarkElfRaceRacialPower : RacialPower
{
    private DarkElfRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DarkElfRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DarkElfRace);
}