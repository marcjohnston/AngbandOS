namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class ZombieRaceRacialPower : RacialPower
{
    private ZombieRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(ZombieRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(ZombieRace);
}