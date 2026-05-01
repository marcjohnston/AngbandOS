namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DwarfRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DwarfRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DwarfRace);
}