namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GnomeRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(GnomeRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.GnomeRace);
}