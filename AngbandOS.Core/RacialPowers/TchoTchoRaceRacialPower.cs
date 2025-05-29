namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class TchoTchoRaceRacialPower : RacialPower
{
    private TchoTchoRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(TchoTchoRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(TchoTchoRace);
}