namespace AngbandOS.GamePacks.Cthangband;

public class SpriteRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SpriteRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SpriteRace);
}