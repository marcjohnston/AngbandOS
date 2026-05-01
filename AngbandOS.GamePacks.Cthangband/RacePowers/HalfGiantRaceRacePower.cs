namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfGiantRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfGiantRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfGiantRace);
}