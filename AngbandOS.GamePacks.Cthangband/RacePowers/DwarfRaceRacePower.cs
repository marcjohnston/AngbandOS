namespace AngbandOS.GamePacks.Cthangband;

public class DwarfRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DwarfRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DwarfRace);
}