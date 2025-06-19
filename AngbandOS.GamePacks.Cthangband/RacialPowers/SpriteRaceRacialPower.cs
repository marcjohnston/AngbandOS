namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpriteRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SpriteRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SpriteRace);
}