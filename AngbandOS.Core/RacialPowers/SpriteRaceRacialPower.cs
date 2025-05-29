namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class SpriteRaceRacialPower : RacialPower
{
    private SpriteRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(SpriteRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(SpriteRace);
}