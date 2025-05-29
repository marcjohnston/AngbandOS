namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class NibelungRaceRacialPower : RacialPower
{
    private NibelungRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(NibelungRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(NibelungRace);
}