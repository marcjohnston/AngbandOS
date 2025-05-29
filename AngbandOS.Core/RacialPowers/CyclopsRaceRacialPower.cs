namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class CyclopsRaceRacialPower : RacialPower
{
    private CyclopsRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(CyclopsRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(CyclopsRace);
}
