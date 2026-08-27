namespace AngbandOS.GamePacks.Cthangband;

public class CyclopsRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(CyclopsRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.CyclopsRace);
}
