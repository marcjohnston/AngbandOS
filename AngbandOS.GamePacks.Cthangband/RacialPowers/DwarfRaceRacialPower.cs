namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DwarfRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DwarfRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DwarfRace);
}