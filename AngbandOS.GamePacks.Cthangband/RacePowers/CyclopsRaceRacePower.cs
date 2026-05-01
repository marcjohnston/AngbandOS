namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CyclopsRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(CyclopsRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.CyclopsRace);
}
