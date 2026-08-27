namespace AngbandOS.GamePacks.Cthangband;

public class NibelungRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(NibelungRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.NibelungRace);
}