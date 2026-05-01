namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTrollRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfTrollRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
}