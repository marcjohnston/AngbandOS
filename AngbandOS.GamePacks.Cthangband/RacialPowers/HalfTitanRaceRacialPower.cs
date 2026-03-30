namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTitanRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfTitanRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfTitanRace);
}