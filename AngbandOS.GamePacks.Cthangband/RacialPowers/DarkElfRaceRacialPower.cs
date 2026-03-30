namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarkElfRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DarkElfRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DarkElfRace);
}