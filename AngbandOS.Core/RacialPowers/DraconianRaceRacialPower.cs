namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRaceRacialPower : RacialPower
{
    private DraconianRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceBaseRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
}