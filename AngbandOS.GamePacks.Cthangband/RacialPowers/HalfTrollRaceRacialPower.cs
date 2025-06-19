namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTrollRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfTrollRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
}