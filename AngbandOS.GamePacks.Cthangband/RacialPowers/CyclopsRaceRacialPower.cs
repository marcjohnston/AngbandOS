namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CyclopsRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(CyclopsRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.CyclopsRace);
}
