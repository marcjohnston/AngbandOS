namespace AngbandOS.GamePacks.Cthangband;

public class DarkElfRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DarkElfRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DarkElfRace);
}