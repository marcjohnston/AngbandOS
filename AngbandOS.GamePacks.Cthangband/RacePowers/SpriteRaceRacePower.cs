namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpriteRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SpriteRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SpriteRace);
}