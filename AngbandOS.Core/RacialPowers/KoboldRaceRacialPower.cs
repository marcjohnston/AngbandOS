namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class KoboldRaceRacialPower : RacialPower
{
    private KoboldRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(KoboldRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(KoboldRace);
}