namespace AngbandOS.GamePacks.Cthangband;

public class DwarfRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DwarfRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DwarfRace);
}