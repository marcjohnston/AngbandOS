namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class MindFlayerRaceRacialPower : RacialPower
{
    private MindFlayerRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(MindFlayerRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(MindFlayerRace);
}