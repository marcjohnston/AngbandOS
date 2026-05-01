namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarkElfRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DarkElfRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DarkElfRace);
}