namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfGiantRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfGiantRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfGiantRace);
}