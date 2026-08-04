namespace AngbandOS.GamePacks.Cthangband;

public class GnomeRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(GnomeRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.GnomeRace);
}