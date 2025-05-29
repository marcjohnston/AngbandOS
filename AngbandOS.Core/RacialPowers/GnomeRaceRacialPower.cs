namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class GnomeRaceRacialPower : RacialPower
{
    private GnomeRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(GnomeRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(GnomeRace);
}